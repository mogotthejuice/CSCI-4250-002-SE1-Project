using System;
using GameLibrary.Models;
using GameLibrary.Models.Locations;
using GameLibrary.Services;

namespace TestConsoleUI {
    class Program {
        static void Main(string[] args) {
            GameController controller = new GameController();
            var players = controller.InitializePlayers(new string[] { "Player 1", "Player 2", "Player 3", "Player 4" });
            var locations = controller.InitializeLocations();

            int i = 2;
            foreach (var item in locations) {
                
                Console.WriteLine($"Name: {item.Name} Max Devs: {item.NumDeveloperSpaces} Num Dev Spaces: {item.SpacesLeft} "); // could not cast item as Resource location -- (ResourceLocation)item.Resource

                controller.PlaceDevelopers(players[0], i, item);
                i=(i+1)%3;
            }
            Console.WriteLine("------");
            foreach (var item in locations) {


                Console.WriteLine($"Name: {item.Name} Max Devs: {item.NumDeveloperSpaces} Num Dev Spaces: {item.SpacesLeft} "); // could not cast item as Resource location -- (ResourceLocation)item.Resource
            }
        }
    }
}
