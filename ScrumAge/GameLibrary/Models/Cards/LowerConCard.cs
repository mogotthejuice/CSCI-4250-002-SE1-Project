using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Models 
{
    public class LowerConCard
    {
        private int FarmerMarkerPoints;
        private int ToolPoints;
        private int BuildingPoints;
        private int ShamanFigurePoints;

         

        
   public int farmerNumber
   {
      get => fNumber;
      set => fNumber = fNumberValue;
   }

   public int Marker
   {
      get => marker;
      set => marker = markerValue;
   }
    public int ToolMakers
   {
      get => fNumber;
      set => TMakers = TMakersValue;
   }
   public int ToolTiles
   {
      get => Ttiles;
      set => Ttiles = TtilesValue;

   }
   public int Builders
   {
      get => BuilderNum;
      set => BuilderNum = BuilderNumValue;

   }
   public int BuildingTiles
   {
      get => buildingTiles;
      set => buildingTiles = buildingTilesValue;

   }
   public int Shamans
   {
      get => shamans;
      set => shamans = shamansValue;

   }
   public int BoardFigures
   {
    
      get => bFigures;
      set => bFigures = bFiguresValue;

   }
   public int calcPoints{

       
   }

    public LowerConCard()
    {
        //determine ties or winner
        points = 0;
            if (points.isEqual())
            { }
            else {}
        }











    }
}