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
         public int DiceRollNumber
            {
                get => diceRollNumber;
                set => diceRollNumber = Value;
            }
            public string CardResources
            {
                get => resources;
                set => resources = Value;
            }

        public string FoodTokens
            {
                get => tokens;
                set => tokens = Value;
            }
        public int VictoryPoints
            {
                get => victoryPoints;
                set => victoryPoints = Value;
            }
        public string DiceRollResources
            {
                get => diceResources;
                set => diceResources = Value;
            }
        public string ToolTiles
            {
                get => toolTiles;
                set => toolTiles = Value;
            }
        public string AgriculturalExtraSpace
            {
                get => Aspace;
                set => Aspace = Value;
            }
        public int CivilizationCard
            {
                get => civCard;
                set => civCard = Value;
            }

        public UpperConCard(int diceRollNumber, string resources)
            {
                
            }
            
            

    }
}