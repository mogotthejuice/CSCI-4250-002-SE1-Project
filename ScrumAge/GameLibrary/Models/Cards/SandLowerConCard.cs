using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models.Cards
{
	public class SandLowerConCard : LowerConCard
	{
		public SandConCardPerson Person { get; private set; }
		public int NumPeople { get; private set; }

		public SandLowerConCard(SandConCardPerson person, int numPeople)
		{
			Person = person;
			NumPeople = numPeople;
		}
	}
}
