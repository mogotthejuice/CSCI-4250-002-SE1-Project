using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Models {
    public class ConsultantCard {
        
        public int diceRollNumber;
        public int cardResources;

        public int foodTokens;
        public int victoryPoints ;
        public int diceRollResources;
        public string toolTiles ;
        public string agriculturalSpaces;
        public int civCard;
        public int FarmerNumber ;
        public int Marker ;
        public int ToolMakers ;
        public int ToolTiles ;
        public int Builders ;
        public int BuildingTiles ;
        public int Shamans;
        public int BoardFigures;    


        public ConsultantCard() 
        {
            UpperConCard Upper = new UpperConCard(diceRollNumber,cardResources, foodTokens,victoryPoints,diceRollResources,toolTiles, agriculturalSpaces,civCard);
            LowerConCard  Lower = new LowerConCard(FarmerNumber,Marker,ToolMakers, ToolTiles,Builders,BuildingTiles,Shamans, BoardFigures);
        
        }
    }
}