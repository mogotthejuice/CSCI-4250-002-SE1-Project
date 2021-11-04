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
            Upper = upper;
            Lower = lower;
        }
    }
}