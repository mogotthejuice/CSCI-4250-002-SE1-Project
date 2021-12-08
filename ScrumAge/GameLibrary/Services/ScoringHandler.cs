using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;
using GameLibrary.Models.Cards;

namespace GameLibrary.Services
{
	public class ScoringHandler
	{
		private static Gameboard game = Gameboard.GetInstance();

		public static void CalcFinalScores()
		{
			foreach (Player player in game.Players)
			{
				CalcGreenConCardScores(player);
				CalcSandConCardScores(player);
				CalcResourcesScores(player);
			}
		}

		private static void CalcGreenConCardScores(Player player)
		{
			// There are only 2 of each card, so just need to account for 2 sets.
			ISet<GreenConCardBackground> firstSet = new HashSet<GreenConCardBackground>();
			ISet<GreenConCardBackground> secondSet = new HashSet<GreenConCardBackground>();

			foreach (ConsultantCard card in player.Board.ConsultantCards)
			{
				if (card.Lower is GreenLowerConCard)
				{
					GreenConCardBackground background = ((GreenLowerConCard) card.Lower).Background;
					if (firstSet.Contains(background))
						secondSet.Add(background);
					else
						firstSet.Add(background);
				}
			}

			player.Score += firstSet.Count * firstSet.Count;
			player.Score += secondSet.Count * secondSet.Count;
		}

		private static void CalcSandConCardScores(Player player)
		{
			foreach (ConsultantCard card in player.Board.ConsultantCards)
			{
				if (card.Lower is SandLowerConCard)
				{
					SandLowerConCard cardLower = (SandLowerConCard) card.Lower;
					switch (cardLower.Person)
					{
						case SandConCardPerson.THERAPIST:
							player.Score += cardLower.NumPeople * player.Board.NumDevelopersOwned;
							break;
						case SandConCardPerson.NERD:
							player.Score += cardLower.NumPeople * CalcTotalOverclockValue(player);
							break;
						case SandConCardPerson.INVESTOR:
							player.Score += cardLower.NumPeople * player.Board.NumBitcoinInvestments;
							break;
						case SandConCardPerson.LAWYER:
							player.Score += cardLower.NumPeople * player.Board.LicenseTiles.Count;
							break;
						default:
							break;
					}

				}
			}
		}

		private static int CalcTotalOverclockValue(Player player)
		{
			int value = 0;
			foreach (Overclock overclock in player.Board.Overclocks)
				value += overclock.Level;

			return value;
		}

		private static void CalcResourcesScores(Player player)
		{
			Resources[] resources = { Resources.Coffee, Resources.USB_Sticks,
									  Resources.CPU_Cores, Resources.Power };

			foreach (Resources resource in resources)
				player.Score += player.Board.GetNumResource(resource);
		}
	}
}
