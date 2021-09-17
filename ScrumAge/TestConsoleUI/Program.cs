using System;
using GameLibrary;

namespace TestConsoleUI {
    class Program {
        static void Main(string[] args) {s
            Fish fish = new Fish();
            Console.WriteLine($"Hello {fish.Name}. You weight {fish.Weight}lbs.");
        }
    }
}
