using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Models;

namespace GameLibrary.Models {
    public class ConsultantCard {
        public UpperConCard Upper { get; private set; }
        public ILowerConCard Lower { get; private set; }  
        
        public ConsultantCard(UpperConCard upper, ILowerConCard lower) 
        {
            Upper = upper; //either immediate or later reward 
            Lower = lower; //either green or sand
        }

        //the associated methods should only be called if that type of card is being used
        public void ImmediateAction(){ 

        }

        public void EndGameAction() {

        }
    }
}