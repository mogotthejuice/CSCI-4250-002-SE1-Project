using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Models {
    public class UpperConCard {
    
    public UpperCardComponents Component {get; private set;}

    public int Number {get; private set}

    

        public UpperConCard(UpperCardComponents component, int number)
         {
             Component = component;
             Number = number;

         }

        

    }
}