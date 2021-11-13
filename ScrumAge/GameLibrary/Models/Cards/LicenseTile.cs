using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Services;

namespace GameLibrary.Models {
    public class LicenseTile {
        private const int COFFEE_VALUE = 3;
        private const int USB_STICKS_VALUE = 4;
        private const int CPU_CORES_VALUE = 5;
        private const int POWER_VALUE = 6;

        private const int MAX_RESOURCES_USED = 7;

        public LicenseTileType Type { get; private set; }
        
        public Dictionary<Resources, int> RequiredResources { get; private set; }  //used when type = FIXED_RESOURCES
        public int NumResources { get; private set; }                   //used when type = FIXED_NUM_RESOURCES
        public int NumResourceTypes { get; private set; }               //used when type = FIXED_NUM_RESOURCES

        public LicenseTile() {
            Type = LicenseTileType.VARIABLE_NUM_RESOURCES;
        }

        public LicenseTile(Dictionary<Resources, int> requiredResources) {
            RequiredResources = requiredResources;
            Type = LicenseTileType.FIXED_RESOURCES;
        }

        public LicenseTile(int numResources, int numResourceTypes) {
            NumResources = numResources;
            NumResourceTypes = numResourceTypes;
            Type = LicenseTileType.FIXED_NUM_RESOURCES;
        }

        public int GetScore(Dictionary<Resources, int> resources) {
            if (Type == LicenseTileType.FIXED_RESOURCES) {
                foreach (Resources resource in RequiredResources.Keys)
                    if (RequiredResources[resource] != resources[resource]) {
                        throw new InvalidOperationException("Must use correct numbers of resources to purchase LicenseTile.");
                    }
            }
            else if (Type == LicenseTileType.FIXED_NUM_RESOURCES) {
                if (HelperFunctions.TotalNumResources(resources) != NumResources) {
                    throw new InvalidOperationException($"Must use {NumResources} resources to purchase LicenseTile.");
                }
                else {
                    int numTypes = 0;
                    foreach (int value in resources.Values)
                        if (value > 0)
                            numTypes++;

                    if (numTypes != NumResourceTypes)
                        throw new InvalidOperationException($"Must use {NumResourceTypes} resource types to purchase LicenseTile.");
                }
            }
            else {  //type == VARIABLE_NUM_RESOURCES
                int numResources = HelperFunctions.TotalNumResources(resources);
                if (numResources > MAX_RESOURCES_USED || numResources <= 0)
                    throw new InvalidOperationException($"Must purchase LicenseTile using between 1 and {MAX_RESOURCES_USED} resources.");
            }

            return calcScore(resources);
        }

        private int calcScore(Dictionary<Resources, int> resources) {
            int score = 0;
            foreach (Resources resource in resources.Keys)
            {
                switch (resource)
                {
                    case Resources.Coffee:
                        score += resources[resource] * COFFEE_VALUE;
                        break;
                    case Resources.USB_Sticks:
                        score += resources[resource] * USB_STICKS_VALUE;
                        break;
                    case Resources.CPU_Cores:
                        score += resources[resource] * CPU_CORES_VALUE;
                        break;
                    case Resources.Power:
                        score += resources[resource] * POWER_VALUE;
                        break;
                    default:
                        throw new InvalidOperationException($"Cannot calculate score using invalid resource {resource}.");
                        break;
                }
            }

            return score;
        }
    }
}