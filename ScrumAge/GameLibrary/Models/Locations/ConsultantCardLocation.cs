using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Services;

namespace GameLibrary.Models.Locations
{
	public class ConsultantCardLocation : AbstractLocation	{
		public ConsultantCard Card { get; set; }
		public int Cost { get; private set; }

		public ConsultantCardLocation(int cost = 1) {
			Name = "Consultant Card";
			numPlayerDevelopers = new List<int>() { 0, 0, 0, 0 };
			NumDeveloperSpaces = 1;
			Cost = cost;
		}

		public override void TakeAction(ref Player player) {
			player.Board.AddConsultantCard(Card);
			Card = null;
			ConCardHandler.MethodPicker();
			ResetPlayerDevelopers(player);
			GameController.CheckEndOfTakeActionsRound();
		}
	}
}
