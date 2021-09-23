using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Interfaces
{
    public interface ILocation
    {
        public string Name { get; set; }
        public int MAX_PLAYERS { get; set; }
        public int NumDeveloperSpaces { get; }
    }
}
