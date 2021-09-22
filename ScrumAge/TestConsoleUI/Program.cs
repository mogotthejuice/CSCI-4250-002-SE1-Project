using System;
using GameLibrary.Models;
using GameLibrary.Models.Locations;
using GameLibrary.Services;

namespace TestConsoleUI {
    class Program {
        static void Main(string[] args) {
            GameController controller = new GameController();

            foreach (var item in controller.Locations) {
                Console.WriteLine($"Name: {item.Name} Max Devs: {item.MAX_PLAYERS} Num Dev Spaces: {item.NumDeveloperSpaces} Resource: {null}"); // could not cast item as Resource location -- (ResourceLocation)item.Resource
            }
        }
    }
}
