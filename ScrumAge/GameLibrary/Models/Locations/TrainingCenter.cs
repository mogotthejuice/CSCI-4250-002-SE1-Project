using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models.Locations {
    public class TrainingCenter : AbstractLocation {
        public TrainingCenter() {
            Name = "Training Center";
            numPlayerDevelopers = new List<int>() { 0, 0, 0, 0 };
            NumDeveloperSpaces = 2;
        }

        public override void TakeAction(ref Player player) {
            throw new NotImplementedException();
        }
    }
}
