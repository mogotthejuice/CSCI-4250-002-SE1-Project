using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Models {
    public class ConsultantCard {
        public UpperConCard Upper { get; private set; }
        public LowerConCard Lower { get; private set; }

        public ConsultantCard() {
            UpperConCard Upper = new UpperConCard(diceRollNnumber,cardResources, foodTokens,victoryPoints,diceRollResources,toolTiles, agriculturalSpaces,civCard);
            LowerConCard  Lower = new LowerConCard(FarmerNumber,Marker,ToolMakers, ToolTiles,Builders,BuildingTiles,Shamans, BoardFigures);
        }
    }
}