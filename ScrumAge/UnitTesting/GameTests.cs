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
        public void Throw_InvalidNumDevs_ResourceLocation_PlacedDevs_Test(int devs, ILocation loc) {
            Assert.Throws<ArgumentException>(() => GameController.PlaceDevelopers(game.Players.Peek(), devs,loc));
        }


        public static IEnumerable LocationTestCases {
            get
            {
                Gameboard game = GameController.InitializeGameboard("p1;p2;p3;p4");
                
                yield return new TestCaseData(100, game.GetLocation("Staples"));
                yield return new TestCaseData(0, game.GetLocation("Staples"));
                yield return new TestCaseData(-5, game.GetLocation("Staples"));
                yield return new TestCaseData(12, game.GetLocation("Staples"));
                yield return new TestCaseData(52, game.GetLocation("Staples"));
                yield return new TestCaseData(12, game.GetLocation("Staples"));
            }
        }
    }
    
}