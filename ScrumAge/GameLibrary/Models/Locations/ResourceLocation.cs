using GameLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models.Locations {
    public class ResourceLocation : AbstractLocation {
        public Resources Resource { get; set; }
        public int Divisor { get; set; }
        public ResourceLocation() {
            numPlayerDevelopers = new List<int>() { 0, 0, 0, 0 };
        }

        public override void TakeAction(ref Player player) {
            // I kept the dice roll seperate in case we would like to add a logging functionality in.
            // This could be fixed to just return the added amount in the service.
            int diceRoll = GameFunctions.DiceRoll();
            int numberOfDevs = numPlayerDevelopers[player.Number - 1];
            
            int amountToAdd = diceRoll * numberOfDevs / Divisor;

            int currentCount;
            player.Board.NumResources.TryGetValue(Resource, out currentCount);
            player.Board.NumResources[Resource] = currentCount + amountToAdd;
            ResetPlayerDevelopers(player);
        }
    }
}
