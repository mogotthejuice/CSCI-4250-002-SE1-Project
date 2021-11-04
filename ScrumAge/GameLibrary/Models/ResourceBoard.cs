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
        public Dictionary<Resources, int> NumResources { get; set; }
        public List<Overclock> Overclocks { get; private set; }
        public List<ConsultantCard> ConsultantCards;
        public List<LicenseTile> LicenseTiles;

        public ResourceBoard() {
            NumDevelopersOwned = START_NUM_DEVELOPERS_OWNED;
            NumDevelopersUnplaced = START_NUM_DEVELOPERS_OWNED;
            NumBitcoinInvestments = 0;

            NumResources = new Dictionary<Resources, int>();
            Resources[] resources = { Resources.Coffee, Resources.USB_Sticks,
                                      Resources.CPU_Cores, Resources.Power };
            foreach (Resources resource in resources) {
                NumResources[resource] = 0;
            }
            NumResources[Resources.Money] = START_NUM_MONEY;

            ConsultantCards = new List<ConsultantCard>();
            LicenseTiles = new List<LicenseTile>();
            Overclocks = new List<Overclock>();
        }

        public int GetNumResource(Resources resource) {
            if (resource == Resources.Overclock)
                throw new ArgumentException("Cannot get number of overclocks. Use overclock-specific methods.");

            return NumResources[resource];
        }

        public void AddBitcoin() {
            if (NumBitcoinInvestments == MAX_BITCOIN_INVESTMENTS)
                throw new InvalidOperationException("Cannot add bitcoin investment when max number of investments owned.");

            NumBitcoinInvestments += 1;   
        }

        public void AddDeveloper() {
            if (NumDevelopersOwned == MAX_DEVELOPERS_OWNED)
                throw new InvalidOperationException("Cannot add developer when max number of developers owned.");

            NumDevelopersOwned += 1;
            NumDevelopersUnplaced += 1;
        }
        
        public void AddConsultantCard(ConsultantCard consultantCard) {
            if (consultantCard is null)
                throw new ArgumentNullException("Cannot add null ConsultantCard.");

            ConsultantCards.Add(consultantCard);
        }

        public void AddLicenseTile(LicenseTile licenseTile) {
            if (licenseTile is null)
                throw new ArgumentNullException("Cannot add null LicenseTile.");

            LicenseTiles.Add(licenseTile);
        }

        public int TotalNumResources() {
            int total = 0;

            Resources[] resources = { Resources.Coffee, Resources.USB_Sticks,
                                      Resources.CPU_Cores, Resources.Power };
            foreach (Resources resource in resources)
            {
                total += NumResources[resource];
            }

            return total;
        }
    }
}