using System;
using System.Threading;

namespace w05d01m02 {
    class Program {
        static void Main(string[] args) {
            int[] data = new int[70];
            var random = new Random();

            for (int i = 0; i < data.Length; i++) {
                data[i] = random.Next(20);
                DisplayData(data);
            }

            // Bubble sort

            // Go through the list number by number and compare it to its next neighbor.
            // If the next neighbor is smaller than the previous one, swap them!
            // Continue until we reach the end.
            // Each time we go through the list, the highest neighbor will 'bubble' to the end.
            // This means we have to sort a smaller and smaller part of the list as we go on.
            // We'll decrease our sorting range one by one until the whole list is sorted.
            for (int sortingRange = data.Length; sortingRange > 0; sortingRange--) {
                // Now we go from the start of the list to the end of the sorting range.
                for (int i = 0; i < sortingRange; i++) {
                    // Look at the next neighbor and see if it's smaller.
                    if (data.Length - 1 > i) {
                        if (data[i + 1] < data[i]) {
                            // It is smaller! We need to switch them.
                            var oldRight = data[i + 1];
                            data[i + 1] = data[i];
                            data[i] = oldRight;
                        }
                    }
                    // Display data for diagnostic purposes.
                    DisplayData(data);
                }
            }
        }
        static void DisplayData(int[] data) {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            for (int y = 20; y >= 0; y--) {
                if (y % 5 == 0) {
                    Console.Write($"{y,3} |");
                }
                else {
                    Console.Write("    |");
                }

                for (int x = 0; x < data.Length; x++) {
                    if (y == 0) {
                        Console.Write("-");
                        continue;
                    }

                    Console.Write(y <= data[x] ? "\u2592" : " ");
                }

                Console.WriteLine();
            }

            Thread.Sleep(10);
        }
    }
}
