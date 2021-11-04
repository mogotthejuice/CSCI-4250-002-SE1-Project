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
       

        public static int DiceRoll(int numberDice, int overclockAddition) {
            int sum = 0;
            Random random = new Random();
            for (int i = 0; i < numberDice; i++) {
                sum += random.Next(1, 6); ;
            }

            sum += overclockAddition;

            return sum;
        }

        /// <summary>
        /// Rolls a dice for each dev on the location belonging to the player
        /// </summary>
        /// <param name="numberDice">number of player's devs at the location</param>
        /// <returns>the sum total of the dice rolls</returns>
        public static int DiceRoll(int numberDice) {
            int sum = 0;
            Random random = new Random();
            for (int i = 0; i < numberDice; i++) {
                sum+= random.Next(1, 6); ;
            }

            return sum;
        }
    }
}
