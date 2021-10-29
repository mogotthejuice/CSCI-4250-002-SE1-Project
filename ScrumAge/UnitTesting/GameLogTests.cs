using GameLibrary.Interfaces;
using GameLibrary.Models;
using GameLibrary.Models.Locations;
using GameLibrary.Services;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting {
    [TestFixture]
    public class GameLogTests {

        public GameBoard Game {get;set;}

        [SetUp]
        public void BaseSetUp() {
            GameController.InitializeGameboard("p1;");
        }

        [Test]
        public void GetInstance_Test() {
            Assert.IsNotNull(GameLog.GetInstance());
        }

        [TestCaseSource("Invalid_LocationSelect_TestCases")]
        public void InvalidLocationSelection_Test(int numDevelopers, ILocation loc) {
            Player player = Gameboard.GetInstance().CurrentPlayer;

            GameController.PlaceDevelopers(numDevelopers, loc);

            Assert.That(GameLog.GetInstance().CurrentMessage.StartsWith("Sorry, "), Is.True);
        }

        

        [TestCaseSource("Valid_TakeAction_TestCases")]
        public void ValidTakeAction_Test(int devs, ILocation loc) {
            Player player = Gameboard.GetInstance().CurrentPlayer;
            
            
            GameController.PlaceDevelopers(devs, loc);
            GameController.PlaceDevelopers(player.Board.NumDevelopersUnplaced, Gameboard.GetInstance().GetLocation("Overtime"));

            GameController.TakeLocationAction(loc);
            
            Assert.That(GameLog.GetInstance().CurrentMessage.StartsWith($"{player.Name}"), Is.True, $"{GameLog.GetInstance().CurrentMessage} \n{player.Board.NumDevelopersUnplaced} \n{loc.Name} \n{devs} {player.Name}");
        }

        [TestCaseSource("Invalid_TakeAction_TestCases")]
        public void InvalidTakeAction_Test(ILocation loc) {
            Player player = Gameboard.GetInstance().CurrentPlayer;

            GameController.TakeLocationAction(loc);


            Assert.That(GameLog.GetInstance().CurrentMessage.StartsWith("Sorry, "), Is.True);
        }

        [TestCase(2, "Training Center")]
        [TestCase(1, "Investment Field")]
        [TestCase(1, "Cafe")]
        [TestCase(1, "Nerd")]
        public void ValidLocationSelection_Test(int numDevelopers, string location) {
            ILocation loc = Gameboard.GetInstance().GetLocation(location);
            Player player = Gameboard.GetInstance().CurrentPlayer;

            GameController.PlaceDevelopers(numDevelopers, loc);

            Assert.That(GameLog.GetInstance().CurrentMessage.Equals($"{player.Name} placed " +
                    $"{numDevelopers} figures."), Is.True, $"{GameLog.GetInstance().CurrentMessage} \n{player.Board.NumDevelopersUnplaced} \n{loc.Name} \n {player.Name}");
        }
        [TearDown]
        public void TearDown() {
            GameController.InitializeGameboard("p1;");
        }

        
        //
        // TEST DATA
        //
        
        public static IEnumerable Invalid_LocationSelect_TestCases {
            get
            {
                Gameboard game = GameController.InitializeGameboard("p1;");

                yield return new TestCaseData(100, game.GetLocation("Cafe"));
                yield return new TestCaseData(0, game.GetLocation("Staples"));
                yield return new TestCaseData(-1, game.GetLocation("Factory"));
                yield return new TestCaseData(11, game.GetLocation("Power Plant"));
                yield return new TestCaseData(52, game.GetLocation("Overtime"));
                yield return new TestCaseData(52, game.GetLocation("Training Center"));
                yield return new TestCaseData(2, game.GetLocation("Investment Field"));
                yield return new TestCaseData(2, game.GetLocation("Nerd"));
                yield return new TestCaseData(2, game.GetLocation("ConsultantCard0"));
                yield return new TestCaseData(2, game.GetLocation("ConsultantCard1"));
                yield return new TestCaseData(2, game.GetLocation("ConsultantCard2"));
                yield return new TestCaseData(2, game.GetLocation("ConsultantCard3"));
                yield return new TestCaseData(2, game.GetLocation("License Tile0"));
                yield return new TestCaseData(2, game.GetLocation("License Tile1"));
                yield return new TestCaseData(2, game.GetLocation("License Tile2"));
                yield return new TestCaseData(0, game.GetLocation("License Tile3"));

            }
        }
        public static IEnumerable Valid_TakeAction_TestCases {
            get
            {
                Gameboard game = GameController.InitializeGameboard("p1;");

                yield return new TestCaseData(2, game.GetLocation("Training Center"));
                yield return new TestCaseData(1, game.GetLocation("Investment Field"));
                yield return new TestCaseData(3, game.GetLocation("Cafe"));
                yield return new TestCaseData(1, game.GetLocation("Nerd"));
            }
        }
        public static IEnumerable Invalid_TakeAction_TestCases {
            get
            {
                Gameboard game = GameController.InitializeGameboard("p1;");

                yield return new TestCaseData(game.GetLocation("Cafe"));
                yield return new TestCaseData(game.GetLocation("Staples"));
                yield return new TestCaseData(game.GetLocation("Factory"));
                yield return new TestCaseData(game.GetLocation("Power Plant"));
                yield return new TestCaseData(game.GetLocation("Overtime"));
                yield return new TestCaseData(game.GetLocation("Training Center"));
                yield return new TestCaseData(game.GetLocation("Investment Field"));
                yield return new TestCaseData(game.GetLocation("Nerd"));
                yield return new TestCaseData(game.GetLocation("ConsultantCard0"));
                yield return new TestCaseData(game.GetLocation("ConsultantCard1"));
                yield return new TestCaseData(game.GetLocation("ConsultantCard2"));
                yield return new TestCaseData(game.GetLocation("ConsultantCard3"));
                yield return new TestCaseData(game.GetLocation("License Tile0"));
                yield return new TestCaseData(game.GetLocation("License Tile1"));
                yield return new TestCaseData(game.GetLocation("License Tile2"));
                yield return new TestCaseData(game.GetLocation("License Tile3"));

            }
        }
    }
}
