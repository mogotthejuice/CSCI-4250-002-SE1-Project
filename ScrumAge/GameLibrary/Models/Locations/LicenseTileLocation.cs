using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Services;

namespace GameLibrary.Models.Locations
{
	public class LicenseTileLocation : AbstractLocation
	{
		public LicenseTile Tile { get { return Tiles.Peek(); } }
		public Queue<LicenseTile> Tiles { get; set; }

		public LicenseTileLocation() {
			Name = "License Tile";
			numPlayerDevelopers = new List<int>() { 0, 0, 0, 0 };
			NumDeveloperSpaces = 1;
			Tiles = new Queue<LicenseTile>();
		}

		public override void TakeAction(ref Player player) {
			player.Board.AddLicenseTile(Tiles.Dequeue());
			ResetPlayerDevelopers(player);
			GameController.CheckEndOfTakeActionsRound();
		}

		public void TakeActionOnDecline(ref Player player)
		{
			ResetPlayerDevelopers(player);
			GameController.CheckEndOfTakeActionsRound();
		}
	}
}
