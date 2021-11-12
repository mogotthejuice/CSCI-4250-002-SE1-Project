using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Models {
    public class Player {
        public int Number { get; set; }
        public string Name { get; set; }
        public int Score {
            get { return Board.NumResources[Resources.Victory_Points]; }
            set { Board.NumResources[Resources.Victory_Points] = value; }
        }
        private Color figColor;
        public string FigColor { get { return figColor.Name; } }
        public ResourceBoard Board { get; private set; }
        
        public Player(int number, Color color, string name = "Player") {
            Number = number;
            Name = name;
            figColor = color;
            Board = new ResourceBoard();
        }
    }
}