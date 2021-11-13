using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Services {

	/*
	 * Provides methods to pay developers at the end of each round.
	 */
	public class PayDevelopersHandler {
		private const int SCORE_PENALTY = 10;

		private static Gameboard game = Gameboard.GetInstance();
		private static GameLog log = GameLog.GetInstance();

		/*
		 * Pays developers with money if possible, and deducts points from players who cannot pay developers.
		 * Returns Dictionary<int, int> mapping player number to number of developers left to pay (can pay with resources).
		 */
		public static Dictionary<int, int> AutoPayDevelopers() {
			Dictionary<int, int> playerNumberToNumDevelopersLeft = new Dictionary<int, int>();
			game.PlayersInRound = new Queue<Player>();

			foreach (Player player in game.Players) {
				int numDevelopersToPay = player.Board.NumDevelopersOwned;
				int numMoney = player.Board.GetNumResource(Resources.Money);

				if (numMoney >= numDevelopersToPay) {
					// Can pay developers with money
					player.Board.NumResources[Resources.Money] -= numDevelopersToPay;
					log.AddMessage($"{player.Name} paid {numDevelopersToPay} developers with money.");
				}
				else {
					// Cannot pay developers with money
					numDevelopersToPay -= player.Board.NumResources[Resources.Money];
					player.Board.NumResources[Resources.Money] = 0;

					if (HelperFunctions.TotalNumResources(player.Board.NumResources) < numDevelopersToPay) {
						// Cannot pay developers with resources
						player.Score -= SCORE_PENALTY;
						log.AddMessage($"{player.Name} could not pay developers, and lost {SCORE_PENALTY} points.");
					}
					else {
						// May pay remaining developers with resources
						playerNumberToNumDevelopersLeft[player.Number] = numDevelopersToPay;
						game.PlayersInRound.Enqueue(player);
					}
				}
			}

			return playerNumberToNumDevelopersLeft;
		}

		/*
		 * Pays the current player's developers using the numResources dictionary passed. If resource payment is
		 * invalid, the current player is not cycled.
		 * Returns true if any player will still need to pay with resources.
		 */
		public static bool CheckResourcePayment(
			Dictionary<int, int> playerNumberToNumDevelopersLeft, Dictionary<Resources, int> numResources) {

			Player player = game.CurrentPlayer;

			// Check that player has enough resources to pay the selected amounts
			int numResourcesPaid = 0;
			foreach (Resources resource in numResources.Keys) {
				if (numResources[resource] > player.Board.NumResources[resource]) {
					log.AddMessage($"{player.Name} cannot pay with more resources than owned. Try again.");
					return true;
				}
				numResourcesPaid += numResources[resource];
			}

			// Check that player has paid the correct number of resources
			if (playerNumberToNumDevelopersLeft[player.Number] != numResourcesPaid)	{
				log.AddMessage($"{player.Name} must pay developers with exactly"
					+ $" {playerNumberToNumDevelopersLeft[player.Number]} resources. Try again.");
				return true;
			}

			// Pay player's developers with resources selected
			foreach (Resources resource in numResources.Keys)
				player.Board.NumResources[resource] -= numResources[resource];
			game.PlayersInRound.Dequeue();

			// Start new round or move to next player
			if (game.PlayersInRound.Count > 0) {
				log.AddMessage($"{player.Name} must pay {playerNumberToNumDevelopersLeft[player.Number]}"
					+ " developers with resources.");
				return true;
			}

			GameController.StartNewRound();
			return false;
		}
	}
}
