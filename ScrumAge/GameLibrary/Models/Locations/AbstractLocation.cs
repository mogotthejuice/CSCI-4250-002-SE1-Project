using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Interfaces;
using GameLibrary.Models;

namespace GameLibrary.Models {
    public abstract class AbstractLocation : ILocation{
        // Number of developers placed on location, with length equal to number of players in game.
        // Ex. List for 4 player game: { P1, P2, P3, P4 }
        protected List<int> numPlayerDevelopers;

        public int MAX_PLAYERS { get; set; } = 4;
        public string Name { get; set; }
        public int NumDeveloperSpaces { get; set; }
        public int SpacesLeft {
            get { return NumDeveloperSpaces - numPlayerDevelopers.Sum(); }
        }

        public int GetNumPlayerDevelopers(Player player) {
            if (player.Number <= 0 || player.Number > MAX_PLAYERS)
                throw new ArgumentException($"Player number must be between 1 and {MAX_PLAYERS}.");

            return numPlayerDevelopers[player.Number - 1];
        }

        protected void SetNumPlayerDevelopers(Player player, int numDevelopers) {
            numPlayerDevelopers[player.Number - 1] = numDevelopers;
        }

        public abstract void PlaceDevelopers(Player player, int numDevelopers);

        public abstract void TakeAction(ref Player player);
    }
    
}