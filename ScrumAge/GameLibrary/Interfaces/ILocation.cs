using GameLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Interfaces
{
    public interface ILocation {
        public string Name { get; set; }
        public int MaxPlayers { get; set; }
        public int SpacesLeft { get; }
        public int NumDeveloperSpaces { get; }
        
        public void PlaceDevelopers(Player player, int numDevelopers);
        int GetNumPlayerDevelopers(Player player);
        public void TakeAction(ref Player player);
        void ResetPlayerDevelopers(Player player);
    }
}
