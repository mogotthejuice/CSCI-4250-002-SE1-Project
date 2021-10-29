using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Models {
    public class UpperConCard 
    {
        
        public enum UpperCardComponents{}
        public int DiceRollNumber { get; set; }
        public int CardResources { get; set; }
        public int FoodTokens { get; set; }
        public int VictoryPoints { get; set; }
        public int DiceRollResources { get; set; }
        public string ToolTiles{ get; set; }
        public string AgriculturalExtraSpace{ get; set; }
        public int CivilizationCard{ get; set; }

        public UpperConCard(int diceRollNnumber, int cardResources, int  foodTokens,int victoryPoints,int diceRollResources, string toolTiles, string agriculturalSpaces, int civCard)
            {
                
            }
            
            

    }
}