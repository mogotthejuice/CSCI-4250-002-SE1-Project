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
        /// <summary>
        /// Initializes Gameboard object's locations and players
        /// </summary>
        /// <param name="players">The name of each player</param>
        /// <returns>A Gameboard object containing Locations and Players</returns>
        public static Gameboard InitializeGameboard(string players) {
            return Gameboard.GetInstance(players);
        }       

        /// <summary>
        /// Place developer at a given location
        /// </summary>
        /// <param name="player">Player to move</param>
        /// <param name="numDevelopers">Number of developers to place</param>
        /// <param name="location">Location to place at</param>
        public static void PlaceDevelopers(Player player, int numDevelopers, ILocation location) {
            if (numDevelopers > player.Board.NumDevelopersUnplaced)
                throw new ArgumentException("Number of developers to place cannot exceed number of developers player has.");

            player.Board.NumDevelopersUnplaced -= numDevelopers;    
            location.PlaceDevelopers(player, numDevelopers);
        }

    }
}
