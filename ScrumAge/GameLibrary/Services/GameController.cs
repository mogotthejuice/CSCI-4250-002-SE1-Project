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
        private const int NUM_CARD_LOCS = 4;

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
            Player player = Gameboard.GetInstance().CurrentPlayer;
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

            CheckEndOfTakeActionsRound();
        }

        public static void TakeLocationAction(ILocation location, int overlockAddition, List<int> overclockIndexes) {
            Player player = Gameboard.GetInstance().CurrentPlayer;
            int numberofDevelopers = location.GetNumPlayerDevelopers(player);

            ResourceLocation loc = (ResourceLocation)location;

            try {
                // check that the player can take action at the given location
                if (numberofDevelopers == 0) {
                    throw new ArgumentException($"Player does not have any developers at {loc.Name}");
                }
                loc.TakeAction(ref player, overlockAddition);
                // here 
                foreach (var index in overclockIndexes) {
                    player.Board.Overclocks.RemoveAt(index);
                }
                
            }
            catch (Exception e) {
                Gameboard.GetInstance().AddToGameLog($"Sorry, {e.Message}");
                return;
            }

            CheckEndOfTakeActionsRound();
        }

        public static void CheckEndOfTakeActionsRound() {
            Gameboard gameboard = Gameboard.GetInstance();
            Player player = gameboard.CurrentPlayer;

            // move to next player if all developers have been used
            if (player.Board.NumDevelopersUnplaced == player.Board.NumDevelopersOwned)
            {
                gameboard.CyclePlayersInRound();
            }

            int totalDevsUnplaced = 0, totalDevsOwned = 0;
            // move to next round if all player developers have been used
            foreach (var p in gameboard.Players)
            {
                totalDevsOwned += p.Board.NumDevelopersOwned;
                totalDevsUnplaced += p.Board.NumDevelopersUnplaced;
            }
            if (totalDevsOwned == totalDevsUnplaced)
            {
                gameboard.Round = GameRound.PAY_DEVELOPERS;
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

            // check expections for max stats
            if (location is TrainingCenter && player.Board.NumDevelopersOwned == ResourceBoard.MAX_DEVELOPERS_OWNED) {
                throw new ArgumentException("Already have max number of developers; action would not do anything.");
            }
            if (location is InvestmentField && player.Board.NumBitcoinInvestments == ResourceBoard.MAX_BITCOIN_INVESTMENTS) {
                throw new ArgumentException("Already have max level of bitcoin; action would not do anything.");
            }
            if (location is NerdLocation && player.Board.Overclocks.Count == ResourceBoard.MAX_OVERCLOCKS) {
                if(player.Board.Overclocks[2].Level == Overclock.MAX_LEVEL)
                    throw new ArgumentException("Already have max amount and level of overclocks; action would not do anything.");
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

        public static void StartNewRound() {
            Gameboard game = Gameboard.GetInstance();
            bool endConditionMet = false;

			// Reset player overclocks
			foreach (Player player in game.Players)
				foreach (Overclock overclock in player.Board.Overclocks)
                    overclock.Reset();

            // Shift consultant cards to right
            ConsultantCardLocation[] cardLocs = new ConsultantCardLocation[NUM_CARD_LOCS];
            for (int i = 0; i < NUM_CARD_LOCS; i++)
                cardLocs[i] = (ConsultantCardLocation)game.GetLocation($"Consultant Card{i}");
            
            Queue<ConsultantCard> cards = new Queue<ConsultantCard>();
            for (int i = NUM_CARD_LOCS - 1; i >= 0; i--) {
                if (cardLocs[i].Card is not null) {
                    cards.Enqueue(cardLocs[i].Card);
                    cardLocs[i].Card = null;
                }
            }

            for (int i = NUM_CARD_LOCS - 1; i >= 0; i--) {
                if (cards.Count > 0)
                    cardLocs[i].Card = cards.Dequeue();
                else if (game.ConCards.Count == 0)
                    endConditionMet = true;
                else
                    cardLocs[i].Card = game.ConCards.Dequeue();
            }

            // Check if any license tile locations are empty
            for (int i = 0; i < NUM_CARD_LOCS; i++) {
                var tileLoc = (LicenseTileLocation)game.GetLocation($"License Tile{i}");
                if (tileLoc.Tiles.Count == 0)
                    endConditionMet = true;
            }

            // Cycle players
            game.CyclePlayers();
            game.PlayersInRound = new Queue<Player>(game.Players);
            game.Round = GameRound.PLACE_FIGURES;

            if (endConditionMet)
                EndGame();
        }

        public static void EndGame() {
            Gameboard game = Gameboard.GetInstance();

            game.Round = GameRound.ENDGAME;
            ScoringHandler.CalcFinalScores();
        }
    }
}