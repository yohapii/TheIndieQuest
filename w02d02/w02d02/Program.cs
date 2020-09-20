using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w02d02 {
    class Program {
        static void Main(string[] args) {
            var random = new Random();

            // Mission 1
            int firstDiceThrow = random.Next(1, 7);
            int secondDiceThrow = random.Next(1, 7);
            int thirdDiceThrow = random.Next(1, 7);
            Console.WriteLine($"First dice throw is {firstDiceThrow}");
            Console.WriteLine($"Second dice throw is {secondDiceThrow}");
            Console.WriteLine($"Third dice throw is {thirdDiceThrow}");
            Console.WriteLine("--");

            // Mission 2:
            Console.WriteLine($"You roll: {firstDiceThrow}, {secondDiceThrow}, {thirdDiceThrow}");
            int score = (firstDiceThrow + secondDiceThrow + (thirdDiceThrow * 3)) * 2;
            Console.WriteLine($"The total score is: {score}");
            Console.WriteLine("--");

            // Mission 3:
            int firstRoll = random.Next(0, 11);
            int secondRoll = random.Next(0, 11 - firstRoll);
            Console.WriteLine($"First roll: {firstRoll}");
            Console.WriteLine($"Second roll: {secondRoll}");
            Console.WriteLine("--");

            // Mission 4:
            int totalShots = random.Next(10, 21);
            int hitShots = random.Next(0, totalShots);
            double hitAccuracy = ((double)hitShots / (double)totalShots) * 100;
            Console.WriteLine($"Total shots: {totalShots}");
            Console.WriteLine($"Hits made: {hitShots}");
            Console.WriteLine($"Hit accuracy: {hitAccuracy}%");
            Console.WriteLine("--");

            // Mission 5:
            double lightYear = 9460730472580800;
            double parsec = 30856775814913673;
            double pcAmountToAC = (lightYear * 4.365) / parsec;
            Console.WriteLine($"The distance to Alpha Centauri is {pcAmountToAC} parsecs.");
            Console.WriteLine("--");
            // Output:
            // The distance to Alpha Centauri is 1.33831508387393 parsecs.
        }
    }
}
