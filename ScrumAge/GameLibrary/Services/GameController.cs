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
        public static void PlaceDevelopers(int numDevelopers, ILocation location) {
            Player player = Gameboard.GetInstance().PlayersInRound.Peek();
            // try to place developer
            try {
                CheckExceptionsPlaceDevelopers(player, numDevelopers, location);

                player.Board.NumDevelopersUnplaced -= numDevelopers;
                location.PlaceDevelopers(player, numDevelopers);
                Gameboard.GetInstance().AddToGameLog($"{player.Name} placed " +
                    $"{numDevelopers} figures.");
            }
            catch (Exception e) {
                Gameboard.GetInstance().AddToGameLog($"Sorry, {e.Message}");
                return;
            }

            Gameboard gameboard = Gameboard.GetInstance();
            if (player.Board.NumDevelopersUnplaced == 0)
            {
                gameboard.PlayersInRound.Dequeue();
                if (gameboard.PlayersInRound.Count == 0)
                {
                    gameboard.PlayersInRound = new Queue<Player>(gameboard.Players);
                    gameboard.Round = GameRound.TAKE_ACTIONS;
                }
            }
            else
            {
                gameboard.CyclePlayersInRound();
            }
        }

        public static void TakeLocationAction(ILocation location) {
            Player player = Gameboard.GetInstance().PlayersInRound.Peek();
            int numberofDevelopers = location.GetNumPlayerDevelopers(player);

            try {
                // check that the player can take action at the given location
                if (numberofDevelopers == 0) {
                    throw new ArgumentException($"Player does not have any developers at {location.Name}");
                }
                location.TakeAction(ref player);
            }
            catch (Exception e) {
                Gameboard.GetInstance().AddToGameLog($"Sorry, {e.Message}");
                return;
            }

            Gameboard gameboard = Gameboard.GetInstance();
            // move to next player if all developers have been used
            if (player.Board.NumDevelopersUnplaced == player.Board.NumDevelopersOwned) {
                gameboard.CyclePlayersInRound();
            }

            int totalDevsUnplaced = 0, totalDevsOwned = 0;
            // move to next round if all player developers have been used
            foreach (var p in gameboard.Players) {
                totalDevsOwned += p.Board.NumDevelopersOwned;
                totalDevsUnplaced += p.Board.NumDevelopersUnplaced;
            }
            if (totalDevsOwned == totalDevsUnplaced) {
                gameboard.Round = GameRound.TALLY_SCORE;
            }
        }

        /// <summary>
        /// Check user input for exceptions relating player or location attributes.
        /// </summary>
        /// <param name="player">Current Player</param>
        /// <param name="numDevelopers">Number of Developers player is trying to place</param>
        /// <param name="location">Location the player is trying to place at</param>
        private static void CheckExceptionsPlaceDevelopers(Player player, int numDevelopers, ILocation location) {
            // check location specific exceptions
            if (location is TrainingCenter && numDevelopers != 2) {
                throw new ArgumentException("Number of developers to place must equal 2.");
            }
            else if (location is InvestmentField && numDevelopers != 1) {
                throw new ArgumentException("Number of developers to place must equal 1.");
            }

            // check exceptions for all locations
            if (numDevelopers > player.Board.NumDevelopersUnplaced) {
                throw new ArgumentException("Number of developers to place cannot exceed number of developers player has.");
            }
            if (numDevelopers > location.SpacesLeft) {
                throw new ArgumentException("Number of developers to place cannot exceed number of spaces left.");
            }
            if (location.GetNumPlayerDevelopers(player) > 0) {
                throw new InvalidOperationException("Cannot place developers on a location where "
                    + "player already has developers.");
            }
            if (numDevelopers < 1) {
                throw new ArgumentException("Need to place at least one developer.");
            }
            
        }
    }
}
