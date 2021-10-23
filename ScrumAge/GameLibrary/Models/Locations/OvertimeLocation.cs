using GameLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models.Locations {
    public class OvertimeLocation : ResourceLocation {
        public override void TakeAction(ref Player player) {
            int diceRoll = GameFunctions.OvertimeDiceRoll(numPlayerDevelopers[player.Number - 1]);
            int numberOfDevs = numPlayerDevelopers[player.Number - 1];

            int amountToAdd = diceRoll * numberOfDevs / Divisor;

            int currentCount;
            player.Board.NumResources.TryGetValue(Resource, out currentCount);
            player.Board.NumResources[Resource] = currentCount + amountToAdd;
            ResetPlayerDevelopers(player);
        }
    }
}
