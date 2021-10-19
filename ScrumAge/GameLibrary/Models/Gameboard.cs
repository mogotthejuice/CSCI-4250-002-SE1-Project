using GameLibrary.Interfaces;
using GameLibrary.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models {
    public class Gameboard {
        private static Gameboard instance;

        /// <summary>
        /// List of each Location
        /// </summary>
        public List<ILocation> Locations { get; set; }
        /// <summary>
        /// Queue of Players; First player in queue is the starting player for the round.
        /// </summary>
        public Queue<Player> Players { get; set; }

		/// <summary>Queue of Players in a Round; First player in queue is player whose turn it is.</summary>
		public Queue<Player> PlayersInRound { get; set; }
        public GameRound Round { get; set; }


        private Gameboard(string players) {
            InitializePlayers(players);
            PlayersInRound = new Queue<Player>(Players);

            InitializeLocations();
            Round = GameRound.PLACE_FIGURES;
        }

        public static Gameboard GetInstance(string players = null) {
            if (instance == null) {
                if (players == null)
                    throw new ArgumentNullException("Gameboard instance not initialized. String for players must be passed.");

                instance = new Gameboard(players);
            }
            
            return instance;
        }

        public void InitializePlayers(string names) {
            Players = new Queue<Player>();
            string []playerNames = names.Split(";");

            for (int i = 0; i < playerNames.Length - 1; i++) {
                Players.Enqueue(new Player(i + 1, playerNames[i]));
            }
        }

        public void InitializeLocations() {
            Locations = new List<ILocation>();
            Locations.Add(new ResourceLocation() {
                Name = "Cafe",
                Resource =
                Resources.Coffee,
                NumDeveloperSpaces = 7
            });
            Locations.Add(new ResourceLocation() {
                Name = "Staples",
                Resource =
                Resources.USB_Sticks,
                NumDeveloperSpaces = 7
            });
            Locations.Add(new ResourceLocation() {
                Name = "Factory",
                Resource =
                Resources.CPU_Cores,
                NumDeveloperSpaces = 7
            });
            Locations.Add(new ResourceLocation() {
                Name = "Power Plant",
                Resource =
                Resources.Power,
                NumDeveloperSpaces = 7
            });
            Locations.Add(new ResourceLocation() {
                Name = "Overtime",
                Resource =
                 Resources.Money,
                NumDeveloperSpaces = int.MaxValue
            });

            Locations.Add(new InvestmentField());
            Locations.Add(new TrainingCenter());
            Locations.Add(new NerdLocation());
			for (int i = 0; i < 4; i++) {
                Locations.Add(new ConsultantCardLocation());
            }
            for (int i = 0; i < 4; i++) {
                Locations.Add(new LicenseTileLocation());
            }
        }

        public void CyclePlayers() {
            Players.Enqueue(Players.Dequeue());
        }

        public void CyclePlayersInRound() {
            PlayersInRound.Enqueue(PlayersInRound.Dequeue());
        }
    }
}
