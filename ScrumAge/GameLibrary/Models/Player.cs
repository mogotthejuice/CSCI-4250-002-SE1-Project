using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Models {
    public class Player {
        public int Number { get; set; }
        public string Name { get; set; }
        public ResourceBoard Board { get; private set; }
        
        public Player(int number, string name = "Player") {
            Number = number;
            Name = name;
            Board = new ResourceBoard();
        }
    }
}