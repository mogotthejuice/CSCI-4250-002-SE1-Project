using NUnit.Framework;
using GameLibrary.Models;
using GameLibrary.Services;
using GameLibrary.Interfaces;
using System;
using System.Collections;

namespace UnitTesting {
    [TestFixture]
    public class GameTests {

        public Gameboard game;
        
        [SetUp]
        public void Setup() {
            game = Gameboard.GetInstance("p1;p2;p3;p4");
        }

        [Test]
        public void Game_Init_Test() {
            Assert.IsNotNull(game);
        }

        
        [TestCaseSource("LocationTestCases")]
        public void InvalidNumDevs_ResourceLocation_PlacedDevs_Test(int devs, ILocation loc) {
            GameController.PlaceDevelopers(devs,loc);
            Assert.That(GameLog.GetInstance().CurrentMessage.StartsWith("Sorry, "), Is.True);
        }

        [Test]
        public void DiceRoll_Test() {
            int x = GameFunctions.DiceRoll();
            Assert.Multiple(() => {
                Assert.Greater(x, 0);
                Assert.Less(x, 13);
            });
            
        }
        [TestCase(1, 1, 6)]
        [TestCase(2, 2, 12)]
        [TestCase(3, 3, 18)]
        [TestCase(4, 4, 24)]
        [TestCase(5, 5, 30)]
        public void OvertimeDiceRoll_Test(int numDevs, int expectedMin, int expectedMax) {
            int x = GameFunctions.OvertimeDiceRoll(numDevs);
            Assert.Multiple(() => {
                Assert.GreaterOrEqual(x, expectedMin);
                Assert.LessOrEqual(x, expectedMax);
            });
        }

        [Test]
        public void GameLog_Init_Test() {
            Gameboard.GetInstance("p1;p2;p3;p4");
            GameLog log = GameLog.GetInstance();

            Assert.AreEqual($"Welcome to SCRUM Age!", log.CurrentMessage);
        }

        public static IEnumerable LocationTestCases {
            get
            {
                Gameboard game = GameController.InitializeGameboard("p1;p2;p3;p4");

                yield return new TestCaseData(100, game.GetLocation("Cafe"));
                yield return new TestCaseData(0, game.GetLocation("Cafe"));
                yield return new TestCaseData(-1, game.GetLocation("Cafe"));
                yield return new TestCaseData(11, game.GetLocation("Cafe"));
                yield return new TestCaseData(52, game.GetLocation("Cafe"));

                yield return new TestCaseData(100, game.GetLocation("Staples"));
                yield return new TestCaseData(0, game.GetLocation("Staples"));
                yield return new TestCaseData(-1, game.GetLocation("Staples"));
                yield return new TestCaseData(11, game.GetLocation("Staples"));
                yield return new TestCaseData(52, game.GetLocation("Staples"));

                yield return new TestCaseData(100, game.GetLocation("Factory"));
                yield return new TestCaseData(0, game.GetLocation("Factory"));
                yield return new TestCaseData(-1, game.GetLocation("Factory"));
                yield return new TestCaseData(11, game.GetLocation("Factory"));
                yield return new TestCaseData(52, game.GetLocation("Factory"));

                yield return new TestCaseData(100, game.GetLocation("Power Plant"));
                yield return new TestCaseData(0, game.GetLocation("Power Plant"));
                yield return new TestCaseData(-1, game.GetLocation("Power Plant"));
                yield return new TestCaseData(11, game.GetLocation("Power Plant"));
                yield return new TestCaseData(52, game.GetLocation("Power Plant"));

                yield return new TestCaseData(0, game.GetLocation("Overtime"));
                yield return new TestCaseData(-1, game.GetLocation("Overtime"));

                yield return new TestCaseData(3, game.GetLocation("Training Center"));
                yield return new TestCaseData(0, game.GetLocation("Training Center"));
                yield return new TestCaseData(-1, game.GetLocation("Training Center"));

                yield return new TestCaseData(2, game.GetLocation("Investment Field"));
                yield return new TestCaseData(0, game.GetLocation("Investment Field"));
                yield return new TestCaseData(-1, game.GetLocation("Investment Field"));

                yield return new TestCaseData(2, game.GetLocation("Nerd"));
                yield return new TestCaseData(0, game.GetLocation("Nerd"));
                yield return new TestCaseData(-1, game.GetLocation("Nerd"));

                yield return new TestCaseData(2, game.GetLocation("ConsultantCard0"));
                yield return new TestCaseData(0, game.GetLocation("ConsultantCard0"));
                yield return new TestCaseData(-1, game.GetLocation("ConsultantCard0"));

                yield return new TestCaseData(2, game.GetLocation("ConsultantCard1"));
                yield return new TestCaseData(0, game.GetLocation("ConsultantCard1"));
                yield return new TestCaseData(-1, game.GetLocation("ConsultantCard1"));

                yield return new TestCaseData(2, game.GetLocation("ConsultantCard2"));
                yield return new TestCaseData(0, game.GetLocation("ConsultantCard2"));
                yield return new TestCaseData(-1, game.GetLocation("ConsultantCard2"));

                yield return new TestCaseData(2, game.GetLocation("ConsultantCard3"));
                yield return new TestCaseData(0, game.GetLocation("ConsultantCard3"));
                yield return new TestCaseData(-1, game.GetLocation("ConsultantCard3"));

                yield return new TestCaseData(2, game.GetLocation("License Tile0"));
                yield return new TestCaseData(0, game.GetLocation("License Tile0"));
                yield return new TestCaseData(-1, game.GetLocation("License Tile0"));

                yield return new TestCaseData(2, game.GetLocation("License Tile1"));
                yield return new TestCaseData(0, game.GetLocation("License Tile1"));
                yield return new TestCaseData(-1, game.GetLocation("License Tile1"));

                yield return new TestCaseData(2, game.GetLocation("License Tile2"));
                yield return new TestCaseData(0, game.GetLocation("License Tile2"));
                yield return new TestCaseData(-1, game.GetLocation("License Tile2"));

                yield return new TestCaseData(2, game.GetLocation("License Tile3"));
                yield return new TestCaseData(0, game.GetLocation("License Tile3"));
                yield return new TestCaseData(-1, game.GetLocation("License Tile3"));
            }
        }
    }
    
}