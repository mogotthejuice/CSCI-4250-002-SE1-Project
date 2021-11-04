﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models.Cards
{
	public class GreenLowerConCard : ILowerConCard
	{
		public GreenConCardBackground Background { get; private set; }

		public GreenLowerConCard(GreenConCardBackground background)
		{
			Background = background;
		}
	}
}
