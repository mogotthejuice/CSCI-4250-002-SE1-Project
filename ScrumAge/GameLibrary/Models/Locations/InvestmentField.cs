﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models.Locations {
    public class InvestmentField : AbstractLocation {
        public InvestmentField() {
            Name = "Investment Field";
            numPlayerDevelopers = new List<int>() { 0};
            NumDeveloperSpaces = 1;
        }
        public override void PlaceDevelopers(Player player, int numDevelopers) {
            if (numDevelopers != 1)
                throw new ArgumentException("Number of developers to place must equal 1.");

            if (numDevelopers > SpacesLeft)
                throw new ArgumentException("Number of developers to place cannot exceed number of spaces left.");

            if (GetNumPlayerDevelopers(player) > 0)
                throw new InvalidOperationException("Cannot place developers on a location where "
                    + "player already has developers.");

            SetNumPlayerDevelopers(player, numDevelopers);
        }

        public override void TakeAction(ref Player player) {
            throw new NotImplementedException();
        }
    }
}