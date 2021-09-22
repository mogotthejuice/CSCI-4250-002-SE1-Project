using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Interfaces {
    public abstract class Location {
        private const int MAX_PLAYERS = 4;

        // Number of developers placed on location, with length equal to number of players in game.
        // Ex. List for 4 player game: { P1, P2, P3, P4 }
        private List<int> numPlayerDevelopers;

        public string Name { get; }
        public int NumDeveloperSpaces { get; }
        public int SpacesLeft {
            get { return NumDeveloperSpaces - numPlayerDevelopers.Sum(); }
        }

        public int GetNumPlayerDevelopers(int player) {
            if (player <= 0 || player > MAX_PLAYERS)
                throw new ArgumentException($"Player number must be between 1 and {MAX_PLAYERS}.");

            return numPlayerDevelopers[player - 1];
        }

        public void PlaceDevelopers(int player, int numDevelopers) {
            if (player <= 0 || player > MAX_PLAYERS)
                throw new ArgumentException($"Player number must be between 1 and {MAX_PLAYERS}.");

            if (numDevelopers > SpacesLeft)
                throw new ArgumentException("Number of developers to place cannot exceed number of spaces left.");

            if (GetNumPlayerDevelopers(player) > 0)
                throw new InvalidOperationException("Cannot place developers on a location where "
                    + "player already has developers.");

            numPlayerDevelopers[player - 1] = numDevelopers;
        }

        public void TakeAction(int player);
    }
}