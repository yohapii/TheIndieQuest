using System;
using System.Collections.Generic;

namespace w03d04m01 {
    class Program {
        static Random rand = new Random();
        static void Main(string[] args) {
            var list = new List<string> { "Matej", "Anni", "Hilda", "Mats", "Nourullah", "David", "Johannes", "Johanna", "André", "Gabriel", "Chris" };

            Console.WriteLine($"Signed-up participants: {string.Join(", ", list)}\n");

            Console.WriteLine("Generating starting order...\n");
            list = ShuffleList(list);

            Console.WriteLine($"Starting order: {string.Join(", ", list)}\n");
        }

        static List<string> ShuffleList(List<string> items, bool debug = false) {
            int timesToShuffle = items.Count;

            for (int i = 0; i < timesToShuffle; i++) {
                int randomPosition = rand.Next(0, items.Count - i);
                if (debug) {
                    Console.WriteLine($"i = {i}, timesToShuffle = {timesToShuffle}");
                    Console.WriteLine($"randomPosition = number between 0 and {items.Count - i - 1} ({items.Count} - {i} - 1) = {randomPosition}");
                }

                if (debug) {
                    Console.WriteLine($"Copying position {randomPosition} to position {items.Count} (newly added)");
                }
                items.Add(items[randomPosition]);

                if (debug) {
                    Console.WriteLine($"Copying position {items.Count - (i + 2)} to position {randomPosition}");
                }
                items[randomPosition] = items[items.Count - (i + 2)];

                if (debug) {
                    Console.WriteLine($"Removing position {items.Count - (i + 2)}, making all position numbers after it be one less\n");
                }
                items.RemoveAt(items.Count - (i + 2));
            }
            return items;
        }
    }
}
