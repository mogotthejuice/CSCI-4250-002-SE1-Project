using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Models {
    public class ResourceBoard {
        private const int MAX_DEVELOPERS_OWNED = 10;
        private const int MAX_BITCOIN_INVESTMENTS = 10;
        private const int MAX_OVERCLOCKS = 3;
        private const int START_NUM_DEVELOPERS_OWNED = 5;
        private const int START_NUM_MONEY = 12;
        
        public int NumDevelopersOwned { get; private set; }
        public int NumDevelopersUnplaced { get; set; }
        public int NumBitcoinInvestments { get; private set; }

        // Mapping of Resource type to number of resource owned by the player
        // Holds number of resource for Money, Coffee, Usb sticks, CPU Cores, and Power
        private Dictionary<Resources, int> numResources;
        private List<ConsultantCard> consultantCards;
        private List<LicenseTile> licenseTiles;
        private List<Overclock> overclocks;

        public ResourceBoard() {
            NumDevelopersOwned = START_NUM_DEVELOPERS_OWNED;
            NumDevelopersUnplaced = START_NUM_DEVELOPERS_OWNED;
            NumBitcoinInvestments = 0;

            numResources = new Dictionary<Resources, int>();
            Resources[] resources = { Resources.Coffee, Resources.USB_Sticks,
                                      Resources.CPU_Cores, Resources.Power };
            foreach (Resources resource in resources) {
                numResources[resource] = 0;
            }
            numResources[Resources.Money] = START_NUM_MONEY;

            consultantCards = new List<ConsultantCard>();
            licenseTiles = new List<LicenseTile>();
            overclocks = new List<Overclock>();
        }

        public int GetNumResource(Resources resource) {
            if (resource == Resources.Overclock)
                throw new ArgumentException("Cannot get number of overclocks. Use overclock-specific methods.");

            return numResources[resource];
        }
        
        public void AddConsultantCard(ConsultantCard consultantCard) {
            consultantCards.Add(consultantCard);
        }

        public void AddLicenseTile(LicenseTile licenseTile) {
            licenseTiles.Add(licenseTile);
        }
        
        public void UpgradeOverclock() {
            if (overclocks.Count < MAX_OVERCLOCKS) {
                overclocks.Add(new Overclock());
            }
            else {
                if (overclocks[MAX_OVERCLOCKS - 1].Level == Overclock.MAX_LEVEL) {
                    throw new InvalidOperationException("Cannot upgrade Overclock when all are max level.");
                }

                int maxLevelOverclockOwned = overclocks[0].Level;
                for (int i = 1; i < overclocks.Count; i++) {
                    if (overclocks[i].Level < maxLevelOverclockOwned) {
                        overclocks[i].Upgrade();
                        return;
                    }
                }

                overclocks[0].Upgrade();
            }
        }
    }
}