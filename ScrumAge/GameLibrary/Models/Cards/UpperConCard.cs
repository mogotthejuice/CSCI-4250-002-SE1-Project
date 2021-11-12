using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Models {
    public class UpperConCard {
        public UpperConCardComponents Components { get; private set; }
        public int Number { get; private set; }
        public Resources Resource { get; private set; }

        public UpperConCard(UpperConCardComponents component, int number, Resources resource = Resources.No_Resource)
        {
            Components = component;
            Number = number;
            Resource = resource;
        }
    }
}