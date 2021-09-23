using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models {
    public class Overclock {
        private const int START_LEVEL = 1;

        public const int MAX_LEVEL = 4;

        public int Level { get; set; }
        public bool HasBeenUsed { get; private set; }

        public void Upgrade() {
            if (Level == MAX_LEVEL)
                throw new InvalidOperationException("Cannot upgrade max level Overclock.");

            Level++;
        }

        public void Use() {
            if (HasBeenUsed)
                throw new InvalidOperationException("Cannot use Overclock that has already been used this turn.");
            
            HasBeenUsed = true;
        }

        public void Reset() {
            HasBeenUsed = false;
        }
    }
}