using GameLibrary.Interfaces;
using GameLibrary.Models.Locations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Models.Cards;

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
        /// <summary>
        /// The pile of Consultant Cards
        /// </summary>
        public Queue<ConsultantCard> ConCards { get; set; }

        /// <summary>Queue of Players in a Round; First player in queue is player whose turn it is.</summary>
        public Queue<Player> PlayersInRound { get; set; }
        public Player CurrentPlayer { get {
                return PlayersInRound.Peek();        
            } 
        }
        public GameRound Round { get; set; }
        
        private Gameboard(string players) {
            InitializePlayers(players);
            PlayersInRound = new Queue<Player>(Players);

            InitializeLocations();
            Round = GameRound.PLACE_FIGURES;

            GameLog gamelog = GameLog.GetInstance();
            AddToGameLog($"Welcome to SCRUM Age!");
        }

        public static Gameboard GetInstance(string players = null) {
            if (instance == null) {
                if (players == null)
                    throw new ArgumentNullException("Gameboard instance not initialized. String for players must be passed.");

                instance = new Gameboard(players);
            }
            
            return instance;
        }
        public ILocation GetLocation(string locationName) {
            ILocation location;

            location = Locations.Find(x => x.Name.Equals(locationName));

            return location;
        }

        public void InitializePlayers(string names) {
            Players = new Queue<Player>();
            string[] playerNames = names.Split(";");

            //Added assiging colors to each player
            List<Color> colorList = new List<Color>() { Color.Yellow, Color.Green, Color.Red, Color.Blue };

            for (int i = 0; i < playerNames.Length - 1; i++) {
                Players.Enqueue(new Player(i + 1, colorList[i], playerNames[i]));
            }
        }

        public void InitializeLocations() {
            Locations = new List<ILocation>();
            Locations.Add(new ResourceLocation() {
                Name = "Cafe",
                Resource =
                Resources.Coffee,
                NumDeveloperSpaces = 7,
                Divisor = 3
            });
            Locations.Add(new ResourceLocation() {
                Name = "Staples",
                Resource =
                Resources.USB_Sticks,
                NumDeveloperSpaces = 7,
                Divisor = 4
            });
            Locations.Add(new ResourceLocation() {
                Name = "Factory",
                Resource =
                Resources.CPU_Cores,
                NumDeveloperSpaces = 7,
                Divisor = 5
            });
            Locations.Add(new ResourceLocation() {
                Name = "Power Plant",
                Resource =
                Resources.Power,
                NumDeveloperSpaces = 7,
                Divisor = 6
            });
            Locations.Add(new ResourceLocation() {
                Name = "Overtime",
                Resource =
                 Resources.Money,
                NumDeveloperSpaces = int.MaxValue,
                Divisor = 2
            });

            Locations.Add(new InvestmentField());
            Locations.Add(new TrainingCenter());
            Locations.Add(new NerdLocation());
			for (int i = 0; i < 4; i++) {
                ConsultantCardLocation cardLoc = new ConsultantCardLocation(cost: 4 - i);
                cardLoc.Name = cardLoc.Name + i.ToString();
                Locations.Add(cardLoc);
            }
            for (int i = 0; i < 4; i++) {
                LicenseTileLocation tileLoc = new LicenseTileLocation();
                tileLoc.Name = tileLoc.Name + i.ToString();
                Locations.Add(tileLoc);
            }

            TempInitializeCardsAndTiles();
        }

        public void CyclePlayers() {
            Players.Enqueue(Players.Dequeue());
        }

        public void CyclePlayersInRound() {
            PlayersInRound.Enqueue(PlayersInRound.Dequeue());
        }

        /// <summary>
        /// Adds a message to the Game Log
        /// </summary>
        /// <param name="message">Message to be added</param>
        public void AddToGameLog(string message) {
            GameLog log = GameLog.GetInstance();
            log.AddMessage(message);
        }

        // Initialize cards and tiles locations with instances of cards/tiles for testing
        private void TempInitializeCardsAndTiles() {
            ConCards = new Queue<ConsultantCard>();
            ConCards.Enqueue(new ConsultantCard(null, null));

            ConsultantCard card = new ConsultantCard(
                new UpperConCard(UpperConCardComponents.RESOURCE, 2, Resources.Power),
                new SandLowerConCard(SandConCardPerson.NERD, 1));
            ((ConsultantCardLocation) GetLocation("Consultant Card0")).Card = card;

            card = new ConsultantCard(
                new UpperConCard(UpperConCardComponents.BITCOIN_INVESTMENT, 1),
                new SandLowerConCard(SandConCardPerson.LAWYER, 2));
            ((ConsultantCardLocation) GetLocation("Consultant Card1")).Card = card;

            card = new ConsultantCard(
                new UpperConCard(UpperConCardComponents.CONSULTANT_CARD, 1),
                new SandLowerConCard(SandConCardPerson.INVESTOR, 3));
            ((ConsultantCardLocation) GetLocation("Consultant Card2")).Card = card;

            card = new ConsultantCard(
                new UpperConCard(UpperConCardComponents.RESOURCE_DICE_ROLL, 1, Resources.Coffee),
                new SandLowerConCard(SandConCardPerson.THERAPIST, 1));
            ((ConsultantCardLocation) GetLocation("Consultant Card3")).Card = card;

            Dictionary<Resources, int> reqResources = new Dictionary<Resources, int>() {
                { Resources.Coffee, 2 }, { Resources.Power, 1 } };
            LicenseTile tile = new LicenseTile(reqResources);
            ((LicenseTileLocation) GetLocation("License Tile0")).Tiles.Enqueue(tile);

            reqResources = new Dictionary<Resources, int>() {
                { Resources.USB_Sticks, 2 }, { Resources.CPU_Cores, 1 } };
            tile = new LicenseTile(reqResources);
            ((LicenseTileLocation) GetLocation("License Tile1")).Tiles.Enqueue(tile);

            tile = new LicenseTile(4, 2);
            ((LicenseTileLocation) GetLocation("License Tile2")).Tiles.Enqueue(tile);

            tile = new LicenseTile();
            ((LicenseTileLocation) GetLocation("License Tile3")).Tiles.Enqueue(tile);
        }
    }
}
