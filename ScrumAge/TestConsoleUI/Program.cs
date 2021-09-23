using System;
using GameLibrary.Models;
using GameLibrary.Models.Locations;
using GameLibrary.Services;

namespace TestConsoleUI {
    class Program {
        static void Main(string[] args) {
           var players = GameController.InitializePlayers(new string[] { "Player 1", "Player 2", "Player 3", "Player 4" });
            var locations = GameController.InitializeLocations();

            int devsToPlace = 2;
            foreach (var location in locations) {
                Console.WriteLine($"Name: {location.Name} Max Devs: {location.NumDeveloperSpaces} Num Dev Spaces: {location.SpacesLeft} "); 

                GameController.PlaceDevelopers(players[0], devsToPlace, location);
                devsToPlace=(devsToPlace+1)%3;
            }
            Console.WriteLine("------");
            foreach (var item in locations) {
                 Console.WriteLine($"Name: {item.Name} Max Devs: {item.NumDeveloperSpaces} Num Dev Spaces: {item.SpacesLeft} "); 
            }
        }
    }
}
