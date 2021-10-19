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
    }
}
