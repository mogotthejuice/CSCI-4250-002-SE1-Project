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
    public class NerdLocationTests {

        Gameboard Game { get; set; }

        [SetUp]
        public void BaseSetUp() {
            Game = GameController.InitializeGameboard("p1;");
            GameController.PlaceDevelopers(1, Game.GetLocation("Nerd"));
            GameController.PlaceDevelopers(4, Game.GetLocation("Overtime"));
            GameController.TakeLocationAction(Game.GetLocation("Nerd"));
            GameController.TakeLocationAction(Game.GetLocation("Overtime"));

            GameController.PlaceDevelopers(1, Game.GetLocation("Nerd"));
            GameController.PlaceDevelopers(4, Game.GetLocation("Overtime"));
            GameController.TakeLocationAction(Game.GetLocation("Nerd"));
            GameController.TakeLocationAction(Game.GetLocation("Overtime"));
            
            GameController.PlaceDevelopers(1, Game.GetLocation("Nerd"));
            GameController.PlaceDevelopers(4, Game.GetLocation("Overtime"));
            GameController.TakeLocationAction(Game.GetLocation("Nerd"));
            GameController.TakeLocationAction(Game.GetLocation("Overtime"));
        }

        [Test]
        public void CheckSetup() {
            var overclocks = Game.CurrentPlayer.Board.Overclocks;
            Assert.That(overclocks.Count == 3);
        }

        [Test]
        public void CheckOverclockAdd() {
            GameController.PlaceDevelopers(5, Game.GetLocation("Overtime"));

            var overclocks = Game.CurrentPlayer.Board.Overclocks;
            var overclockIndexes = new List<int>() { 0};
            int sum = 0;
            foreach (var item in overclockIndexes) {
                sum += overclocks[item].Level;
            }

            GameController.TakeLocationAction(Game.GetLocation("Overtime"), sum, overclockIndexes);

            Assert.That(Game.CurrentPlayer.Board.Overclocks.Count == 2);
        }
        [Test]
        public void CheckMultipleOverclockAdd() {
            GameController.PlaceDevelopers(1, Game.GetLocation("Nerd"));
            GameController.PlaceDevelopers(4, Game.GetLocation("Overtime"));
            GameController.TakeLocationAction(Game.GetLocation("Nerd"));
            GameController.TakeLocationAction(Game.GetLocation("Overtime"));
            GameController.PlaceDevelopers(1, Game.GetLocation("Nerd"));
            GameController.PlaceDevelopers(4, Game.GetLocation("Overtime"));
            GameController.TakeLocationAction(Game.GetLocation("Nerd"));
            GameController.TakeLocationAction(Game.GetLocation("Overtime"));

            GameController.PlaceDevelopers(5, Game.GetLocation("Overtime"));

            var overclocks = Game.CurrentPlayer.Board.Overclocks;
            var overclockIndexes = new List<int>() { 0 , 1};
            int sum = 0;
            foreach (var item in overclockIndexes) {
                sum += overclocks[item].Level;
            }

            GameController.TakeLocationAction(Game.GetLocation("Overtime"), sum, overclockIndexes);

            Assert.That(Game.CurrentPlayer.Board.Overclocks.Count == 1);
        }
    }
}
