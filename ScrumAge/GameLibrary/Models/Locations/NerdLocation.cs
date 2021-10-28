﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models.Locations
{
    class NerdLocation : AbstractLocation {
        private const int MAX_OVERCLOCKS = 4;

        public NerdLocation() {
            Name = "Nerd";
            numPlayerDevelopers = new List<int>() { 0, 0, 0, 0 };
            NumDeveloperSpaces = 1;
        }

        public override void TakeAction(ref Player player) {
            if (player.Board.Overclocks.Count < MAX_OVERCLOCKS) {
                player.Board.Overclocks.Add(new Overclock());
            }
            else {
                if (player.Board.Overclocks[MAX_OVERCLOCKS - 1].Level == Overclock.MAX_LEVEL) {
                    throw new InvalidOperationException("Cannot upgrade Overclock when all are max level.");
                }

                int maxLevelOverclockOwned = player.Board.Overclocks[0].Level;
                for (int i = 1; i < player.Board.Overclocks.Count; i++) {
                    if (player.Board.Overclocks[i].Level < maxLevelOverclockOwned) {
                        player.Board.Overclocks[i].Upgrade();
                        return;
                    }
                }

                player.Board.Overclocks[0].Upgrade();
            }

            ResetPlayerDevelopers(player);
        }
    }
}
