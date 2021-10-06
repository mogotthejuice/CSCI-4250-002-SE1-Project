using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models {
    public class LicenseTile {
        private const int COFFEE_VALUE = 3;
        private const int USB_STICKS_VALUE = 4;
        private const int CPU_CORES_VALUE = 5;
        private const int POWER_VALUE = 6;

        private const int MAX_RESOURCES_USED = 7;

        public LicenseTileType Type { get; private set; }
        
        private List<Resources> requiredResources;  //used when type = FIXED_RESOURCES
        private int numResources;                   //used when type = FIXED_NUM_RESOURCES
        private int numResourceTypes;               //used when type = FIXED_NUM_RESOURCES

        public LicenseTile() {
            Type = LicenseTileType.VARIABLE_NUM_RESOURCES;
        }

        public LicenseTile(List<Resources> _requiredResources) {
            requiredResources = _requiredResources;
            Type = LicenseTileType.FIXED_RESOURCES;
        }

        public LicenseTile(int _numResources, int _numResourceTypes) {
            numResources = _numResources;
            numResourceTypes = _numResourceTypes;
        }

        public int GetScore() {
            if (Type != LicenseTileType.FIXED_RESOURCES)
                throw new InvalidOperationException($"LicenseTile of type {Type} does not have a fixed score."
                    + " Pass a List<Resources> parameter.");

            return calcScore(requiredResources);
        }

        public int GetScore(List<Resources> resources) {
            if (Type == LicenseTileType.FIXED_RESOURCES)
                return GetScore();  //wrong method call

            else if (Type == LicenseTileType.FIXED_NUM_RESOURCES) {
                if (resources.Count != numResources)
                    throw new InvalidOperationException($"Must use {numResources} resources to purchase LicenseTile.");
                else if (resources.Distinct().Count() != numResourceTypes)
                    throw new InvalidOperationException($"Must use {numResourceTypes} resource types to purchase LicenseTile.");
            }
            else {  //type == VARIABLE_NUM_RESOURCES
                if (resources.Count > MAX_RESOURCES_USED)
                    throw new InvalidOperationException($"Must purchase LicenseTile using a max of {MAX_RESOURCES_USED} resources.");
            }

            return calcScore(resources);
        }

        private int calcScore(List<Resources> resources) {
            int score = 0;
            foreach (Resources resource in requiredResources)
            {
                switch (resource)
                {
                    case Resources.Coffee:
                        score += COFFEE_VALUE;
                        break;
                    case Resources.USB_Sticks:
                        score += USB_STICKS_VALUE;
                        break;
                    case Resources.CPU_Cores:
                        score += CPU_CORES_VALUE;
                        break;
                    case Resources.Power:
                        score += POWER_VALUE;
                        break;
                    default:
                        throw new InvalidOperationException($"Cannot calculate score using invalid resource {resource}.");
                }
            }

            return score;
        }
    }
}