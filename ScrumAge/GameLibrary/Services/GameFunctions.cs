using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Services {
    /// <summary>
    /// Class to contain miscellaneous functions such as dice roll
    /// </summary>
    public static class GameFunctions {
        /// <summary>
        /// Rolls two dice and return each value
        /// </summary>
        /// <returns>A tuple, dice 1's roll & dice 2's roll</returns>
        public static int DiceRoll() {
            Random random = new Random();
            int dice1 = random.Next(1,6);
            int dice2 = random.Next(1, 6);

            return dice1 + dice2;
        }

        /// <summary>
        /// Rolls a dice for each dev on the location belonging to the player
        /// </summary>
        /// <param name="numberDice">number of player's devs at the location</param>
        /// <returns>the sum total of the dice rolls</returns>
        public static int OvertimeDiceRoll(int numberDice) {
            int sum = 0;
            Random random = new Random();
            for (int i = 0; i < numberDice; i++) {
                sum+= random.Next(1, 6); ;
            }

            return sum;
        }
    }
}
