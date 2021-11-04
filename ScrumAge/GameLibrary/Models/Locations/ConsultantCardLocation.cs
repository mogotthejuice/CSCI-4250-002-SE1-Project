using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models.Locations
{
	public class ConsultantCardLocation : AbstractLocation	{
		public ConsultantCard Card { get; set; }

		public ConsultantCardLocation() {
			Name = "ConsultantCard";
			numPlayerDevelopers = new List<int>() { 0, 0, 0, 0 };
			NumDeveloperSpaces = 1;
		}

		public override void TakeAction(ref Player player) {
			throw new NotImplementedException();
		}
	}
}
