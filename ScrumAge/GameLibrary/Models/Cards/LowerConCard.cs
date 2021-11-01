using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Models {
    public abstract class LowerConCard {
        //TEMP: These properties are now not needed; subclasses handle all data
        //TODO: Remove all attributes and properties
        private int FarmerMarkerPoints;
        private int ToolPoints;
        private int BuildingPoints;
        private int ShamanFigurePoints;

    
        public int FarmerNumber { get; set; }
        public int Marker { get; set; }
        public int ToolMakers{ get; set; }
        public int ToolTiles{ get; set; }
        public int Builders{ get; set; }
        public int BuildingTiles{ get; set; }
        public int Shamans{ get; set; }
        public int BoardFigures{ get; set; }
        // public int calcPoints{}

        //TEMP: Constructor is now also not needed, this class now only exists for Sand and Green subclasses to inherit from
        //TODO: Remove both constructors
        public LowerConCard(int FarmerNumber,int Marker,int ToolMakers, int ToolTiles,int Builders,int BuildingTiles,int Shamans,int  BoardFigures)
        {
        //determine ties or winner
        //points = 0;
           // if (points.isEqual())
            //{ }
            //else {}
        }

        public LowerConCard()
        {
            //temp constructor so subclasses' constructors don't show errors
        }
    }
}