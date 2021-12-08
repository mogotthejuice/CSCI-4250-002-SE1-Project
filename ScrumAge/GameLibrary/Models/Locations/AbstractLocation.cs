using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Interfaces;
using GameLibrary.Models;

namespace GameLibrary.Models {
    public abstract class AbstractLocation : ILocation {
        // Number of developers placed on location, with length equal to number of players in game.
        // Ex. List for 4 player game: { P1, P2, P3, P4 }
        public List<int> numPlayerDevelopers { get; set; }

        public int MaxPlayers { get; set; } = 4;
        public string Name { get; set; }
        public int NumDeveloperSpaces { get; set; }
        public int SpacesLeft {
            get { return NumDeveloperSpaces - numPlayerDevelopers.Sum(); }
        }

        public int GetNumPlayerDevelopers(Player player) {
            if (player.Number <= 0 || player.Number > MaxPlayers)
                throw new ArgumentException($"Player number must be between 1 and {MaxPlayers}.");

            return numPlayerDevelopers[player.Number - 1];
        }

        protected void SetNumPlayerDevelopers(Player player, int numDevelopers) {
            numPlayerDevelopers[player.Number - 1] = numDevelopers;
        }

        public void PlaceDevelopers(Player player, int numDevelopers) {
            SetNumPlayerDevelopers(player, numDevelopers);
        }
        /// <summary>
        /// Sets the developers from the current Player to 0 after taking action.
        /// Adds the developers back to the Player's board.
        /// </summary>
        /// <param name="player">Current Player</param>
        public void ResetPlayerDevelopers(Player player) {
            player.Board.NumDevelopersUnplaced += GetNumPlayerDevelopers(player);
            SetNumPlayerDevelopers(player, 0);
        }

        public abstract void TakeAction(ref Player player);

    }
    
}