using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Services {
	/*
	 * Pays developers with money if possible, and deducts points from players who cannot pay developers.
	 * Returns Dictionary<int, int> mapping player number to number of developers left to pay (can pay with resources).
	 */
	public class PayDevelopersHandler {
		private const int SCORE_PENALTY = 10;

		public static Dictionary<int, int> PayDevelopers() {
			Gameboard board = Gameboard.GetInstance();
			Dictionary<int, int> playerNumberToNumDevelopersLeft = new Dictionary<int, int>();

			foreach (Player player in board.Players) {
				int numDevelopersToPay = player.Board.NumDevelopersOwned;
				int numMoney = player.Board.GetNumResource(Resources.Money);

				if (numMoney >= numDevelopersToPay) {
					// Can pay developers with money
					player.Board.NumResources[Resources.Money] -= numDevelopersToPay;
				}
				else {
					// Cannot pay developers with money
					numDevelopersToPay -= player.Board.NumResources[Resources.Money];
					player.Board.NumResources[Resources.Money] = 0;

					if (player.Board.TotalNumResources() < numDevelopersToPay) {
						// Cannot pay developers with resources
						player.Score -= SCORE_PENALTY;
					}
					else {
						// May pay remaining developers with resources
						playerNumberToNumDevelopersLeft[player.Number] = numDevelopersToPay;
					}
				}
			}

			return playerNumberToNumDevelopersLeft;
		}
	}
}
