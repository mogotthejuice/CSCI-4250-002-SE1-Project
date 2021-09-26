using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Interfaces;
using GameLibrary.Models;
using GameLibrary.Models.Locations;

namespace GameLibrary.Services {
    
    /// <summary>
    /// Initializes Game and acts as the interface between the backend and UI
    /// </summary>
    public static class GameController {

        public static List<ILocation> Locations;


        /// <summary>
        /// Place developer at a given location
        /// </summary>
        /// <param name="player">Player to move</param>
        /// <param name="numDevelopers">Number of developers to place</param>
        /// <param name="location">Location to place at</param>
        public static void PlaceDevelopers(Player player, int numDevelopers, ILocation location) {
            if (numDevelopers > player.NumDevelopersUnplaced)
                throw new ArgumentException("Number of developers to place cannot exceed number of developers player has.");

            player.NumDevelopersUnplaced -= numDevelopers;    
            location.PlaceDevelopers(player, numDevelopers);
        }

        public static List<Player> InitializePlayers(string[] playerNames) {
            List<Player> players = new List<Player>();

            for (int i = 0; i < playerNames.Length; i++) {
                players.Add(new Player(i+1, playerNames[i]));
            }

            return players;
        }

        public static List<ILocation> InitializeLocations() {
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

            return Locations;
        }

        
    }
}
