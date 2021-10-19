﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models.Locations
{
	class LicenseTileLocation : AbstractLocation
	{
		public LicenseTile Tile { get; set; }

		public LicenseTileLocation() {
			Name = "License Tile";
			numPlayerDevelopers = new List<int>() { 0, 0, 0, 0 };
			NumDeveloperSpaces = 1;
		}

		public override void TakeAction(ref Player player) {
			throw new NotImplementedException();
		}
	}
}
