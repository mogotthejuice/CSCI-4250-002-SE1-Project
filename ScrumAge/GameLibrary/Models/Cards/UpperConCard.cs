using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Models {
    public class UpperConCard {
        /*
         * TODO: Move UpperConCardComponent enum to new file with the following constants:
         * DICE_ROLL
         * RESOURCE (will cover food and resource)
         * RESOURCE_DICE_ROLL
         * VICTORY_POINTS
         * OVERCLOCK
         * BITCOIN_INVESTMENT
         * CONSULTANT_CARD
         * ONE_USE_OVERCLOCK
         * ANY_TWO_RESOURCES
         */
        public enum UpperCardComponents{}
        public int DiceRollNumber { get; set; }
        public int CardResources { get; set; }
        public int FoodTokens { get; set; }
        public int VictoryPoints { get; set; }
        public int DiceRollResources { get; set; }
        public string ToolTiles{ get; set; }
        public string AgriculturalExtraSpace{ get; set; }
        public int CivilizationCard{ get; set; }

        public UpperConCard(int diceRollNumber, int cardResources, int  foodTokens,int victoryPoints,int diceRollResources, string toolTiles, string agriculturalSpaces, int civCard)
         {

         }

        

    }
}