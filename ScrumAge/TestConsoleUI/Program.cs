using System;
using GameLibrary.Models;

namespace TestConsoleUI {
    class Program {
        static void Main(string[] args) {
            Fish fish = new Fish();
            Console.WriteLine($"Hello {fish.Name}. You weight {fish.Weight}lbs.");
        }
    }
}
