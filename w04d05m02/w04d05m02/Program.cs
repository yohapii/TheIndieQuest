using System;
using System.Collections.Generic;
using System.Threading;

namespace Chart {
    class Program {
        static Random rand = new Random();

        static void Main(string[] args) {
            /*
            Description: Random list 1
            Type: Normal
            Expected: Sort numbers lowest to highest.
            Actual: Sort numbers lowest to highest.
            */
            var data = new List<int>() { 8, 1, 2, 3, 7, 9, 4, 6, 5, 10 };

            /*
            Description: Random list 2
            Type: Normal
            Expected: Sort numbers lowest to highest.
            Actual: Sort numbers lowest to highest.
            */
            //var data = new List<int>() { 1, 8, 3, 5, 4, 7, 6, 2, 10, 9 };

            /*
            Description: Random negative numbers
            Type: Boundary
            Expected: Sort numbers lowest to highest.
            Actual: Sort numbers lowest to highest.
            */
            //var data = new List<int>() { -7, -9, -1, -5, -4, -8, -3, -6, -2, -10 };

            /*
            Description: List with duplicates
            Type: Boundary
            Expected: Sort numbers lowest to highest.
            Actual: Sort numbers lowest to highest.
            */
            //var data = new List<int>() { 8, 1, 1, 3, 3, 9, 4, 9, 10, 10 };

            /*
            Description: Empty list
            Type: Boundary
            Expected: Empty, no graph
            Actual: Empty, no graph
            */
            //var data = new List<int>();

            if (data.Count > 1) {
                // Insertion sort

                // Split the list between sorted numbers on the left and unsorted on the right.
                // At the start, only the first number is sorted, the rest are unsorted.
                // Then take the first unsorted number and move it to the left until it is in the correct place in the sorted list.
                // Repeat this with all unsorted numbers until all the numbers are in the sorted list.
                int sortedCount = 1;

                do {
                    // Find the first unsorted number.
                    int indexOfFirstUnsortedNumber = sortedCount;
                    int firstUnsortedNumber = data[indexOfFirstUnsortedNumber];

                    // Test the sorted number to the left of it and see if it is bigger.
                    int testIndex = indexOfFirstUnsortedNumber - 1;

                    while (testIndex >= 0 && data[testIndex] > firstUnsortedNumber) {
                        // The sorted number is bigger!
                        // Move the sorted number to the right since it is bigger than the unsorted number.
                        // (Bigger numbers must be on the right of the smaller ones.)
                        data[testIndex + 1] = data[testIndex];

                        // Continue testing the next number on the left.
                        testIndex--;

                        // Display data for diagnostic purposes.
                        DisplayData(data);
                    }

                    // The unsorted number should now be placed into the spot where the last tested number was shifted away from.
                    int insertionIndex = testIndex + 1;
                    data[insertionIndex] = firstUnsortedNumber;

                    // We've successfully sorted a new number.
                    sortedCount++;

                    // Display data for diagnostic purposes.
                    DisplayData(data);

                } while (sortedCount < data.Count);
            }


            Console.WriteLine($"The sorted numbers are: {string.Join(", ", data)}");
        }


        static void DisplayData(List<int> data) {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            for (int y = 20; y >= 0; y--) {
                if (y % 5 == 0) {
                    Console.Write($"{y,3} |");
                }
                else {
                    Console.Write("    |");
                }

                for (int x = 0; x < data.Count; x++) {
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
