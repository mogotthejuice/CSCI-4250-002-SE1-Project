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
        public int diceRollNumber  { get; set; }
        public int cardResources  { get; set; }
        
        public int foodTokens  { get; set; }
        public int victoryPoints  { get; set; }
        public int diceRollResources  { get; set; }
        public string toolTiles { get; set; }
        public string agriculturalSpaces { get; set; }
        public int civCard { get; set; }
        public int civCard { get; set; }
        public int FarmerNumber { get; set; }
        public int Marker { get; set; }
        public int ToolMakers { get; set; }
        public int ToolTiles { get; set; }
        public int Builders { get; set; }
        public int BuildingTiles { get; set; }
        public int Shamans{ get; set; }
        public int BoardFigures{ get; set; }    


        public ConsultantCard() {
            UpperConCard Upper = new UpperConCard(diceRollNumber,cardResources, foodTokens,victoryPoints,diceRollResources,toolTiles, agriculturalSpaces,civCard);
            LowerConCard  Lower = new LowerConCard(FarmerNumber,Marker,ToolMakers, ToolTiles,Builders,BuildingTiles,Shamans, BoardFigures);
        }
    }
}