using System;
using GameLibrary.Interfaces;
using GameLibrary.Models;
using GameLibrary.Models.Locations;
using GameLibrary.Services;

namespace TestConsoleUI {
    class Program {
        static void Main(string[] args) {
           var players = GameController.InitializePlayers(new string[] { "Player 1", "Player 2", "Player 3", "Player 4" });
            var locations = GameController.InitializeLocations();

            foreach (var location in locations) {
                Console.WriteLine($"Name: {location.Name} Max Devs: {location.NumDeveloperSpaces} Num Dev Spaces: {location.SpacesLeft} ");
                if (location is ResourceLocation) {
                    GameController.PlaceDevelopers(players[0], 0, location);
                }
                if (location is InvestmentField) {
                    GameController.PlaceDevelopers(players[0], 1, location);
                }
                if (location is TrainingCenter) {
                    GameController.PlaceDevelopers(players[0], 2, location);
                }
             }
            Console.WriteLine("------");
            foreach (var item in locations) {
                 Console.WriteLine($"Name: {item.Name} Max Devs: {item.NumDeveloperSpaces} Num Dev Spaces: {item.SpacesLeft} "); 
            }
        }
    }
}
