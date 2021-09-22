using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Models;
using GameLibrary.Models.Locations;

namespace GameLibrary.Services {
    /// <summary>
    /// Initializes Game and acts as the interface between the backend and UI
    /// </summary>
    public class GameController {
        public List<AbstractLocation> Locations { get; set; }

        /// <summary>
        /// Initialization class. Locations and Resource Board will be initialized here.
        /// </summary>
        public GameController() {
            // initialize players
            InitializeLocations();
            // initialize cards/tiles
        }

        private void InitializeLocations() {
            Locations = new List<AbstractLocation>();
            Locations.Add(new ResourceLocation() {
                Name = "Cafe",
                Resource =
                Resources.Coffee,
                MAX_PLAYERS = 7
            });
            Locations.Add(new ResourceLocation() {
                Name = "Staples",
                Resource =
                Resources.USB_Sticks,
                MAX_PLAYERS = 7
            });
            Locations.Add(new ResourceLocation() {
                Name = "Factory",
                Resource =
                Resources.CPU_Cores,
                MAX_PLAYERS = 7
            });
            Locations.Add(new ResourceLocation() {
                Name = "Power Plant",
                Resource =
                Resources.Power,
                MAX_PLAYERS = 7
            }); Locations.Add(new ResourceLocation() {
                Name = "Overtime",
                Resource =
                 Resources.Money,
                MAX_PLAYERS = int.MaxValue
            });
            /*still need: 
                training
                investment field
             */
        }
    }
}
