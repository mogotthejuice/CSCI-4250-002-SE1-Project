using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Models {
    public class Player {

        private const int MAX_DEVELOPERS_OWNED = 10;
        private const int MAX_BITCOIN_INVESTMENTS = 10;
        private const int START_NUM_DEVELOPERS_OWNED = 5;

        public int Number { get; set; }
        public string Name { get; set; }
        
        public int NumDevelopersOwned { get; private set; }
        public int NumDevelopersUnplaced { get; set; }
        public int NumBitcoinInvestments { get; private set; }

        
        // Mapping of Resource type to number of resource owned by the player
        // Holds number of resource for Money, Coffee, Usb sticks, CPU Cores, and Power
        private Dictionary<Resources, int> numResources;
        
        public Player(int number, string name = "Player") {
            Number = number;
            Name = name;

            NumDevelopersOwned = START_NUM_DEVELOPERS_OWNED;
            NumDevelopersUnplaced = START_NUM_DEVELOPERS_OWNED;
            NumBitcoinInvestments = 0;
            //TODO: Add list of ConsultantCards
            //TODO: Add list of LicenseTiles
            //TODO: Add functionality for Overclocks

            numResources = new Dictionary<Resources, int>();
            Resources[] resources = { Resources.Money, Resources.Coffee, Resources.USB_Sticks,
                                      Resources.CPU_Cores, Resources.Power };
            foreach (Resources resource in resources) {
                numResources[resource] = 0;
            }
        }

        public int GetNumResource(Resources resource) {
            if (resource == Resources.Overclock)
                throw new ArgumentException("Cannot get number of overclocks. Use overclock-specific methods.");

            return numResources[resource];
        }

    }
}