using GameLibrary.Interfaces;
using GameLibrary.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models {
    public class Gameboard {
        /// <summary>
        /// List of each Location
        /// </summary>
        public List<ILocation> Locations { get; set; }
        /// <summary>
        /// List of Players
        /// </summary>
        public List<Player> Players{ get; set; }

        public Gameboard(string players) {
            InitializePlayers(players);
            InitializeLocations();
        }
        public void InitializePlayers(string names) {
            Players = new List<Player>();
            string []playerNames = names.Split(";");


            for (int i = 0; i < playerNames.Length; i++) {
                Players.Add(new Player(i + 1, playerNames[i]));
            }
            
        }
        public void InitializeLocations() {
            Locations = new List<ILocation>();
            Locations.Add(new ResourceLocation() {
                Name = "Cafe",
                Resource =
                Resources.Coffee,
                NumDeveloperSpaces = 7
            });
            Locations.Add(new ResourceLocation() {
                Name = "Staples",
                Resource =
                Resources.USB_Sticks,
                NumDeveloperSpaces = 7
            });
            Locations.Add(new ResourceLocation() {
                Name = "Factory",
                Resource =
                Resources.CPU_Cores,
                NumDeveloperSpaces = 7
            });
            Locations.Add(new ResourceLocation() {
                Name = "Power Plant",
                Resource =
                Resources.Power,
                NumDeveloperSpaces = 7
            });
            Locations.Add(new ResourceLocation() {
                Name = "Overtime",
                Resource =
                 Resources.Money,
                NumDeveloperSpaces = int.MaxValue
            });

            Locations.Add(new InvestmentField());
            Locations.Add(new TrainingCenter());
            }
    }
}
