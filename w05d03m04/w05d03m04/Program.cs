using System;

namespace w05d03m04 {
    class Program {
        static bool debug = false; // a variable to set if program should print debug lines or not

        static Random rand = new Random();

        static void Main(string[] args) {
            int numberOfResults = 10; // set how many results per throw to show
            int numberOfLoops = 6; // set how many times to loop code

            for (int i = 0; i < numberOfLoops; i++) {
                DiceRoll("1d6", numberOfResults);
                DiceRoll("2d8", numberOfResults);
                DiceRoll("3d6+8", numberOfResults);
                DiceRoll("1d4+4", numberOfResults);

                Console.WriteLine();
            }
        }

        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0) {
            int result = 0;
            for (int i = 0; i < numberOfRolls; i++) {
                result += rand.Next(1, diceSides + 1);
            }
            return result + fixedBonus;
        }

        static void DiceRoll(string diceNotation, int numberOfResults) {
            // convert relevant parts of a correct input string (xdy+z where numbers are between 1-9) to chars to int
            int numberOfRolls = int.Parse(diceNotation[0].ToString());
            int diceSides = int.Parse(diceNotation[2].ToString());
            int fixedBonus = 0;

            // only convert fixed bonus if the input string length means it could include it
            if (diceNotation.Length == 5) {
                fixedBonus = int.Parse(diceNotation[4].ToString());
            }

            // Show debug lines if debug variable is set to true
            if (debug) {
                Console.WriteLine($"\n\nDice notation: {diceNotation}\n");
                Console.WriteLine($"Number of rolls: {numberOfRolls}");
                Console.WriteLine($"Dice sides: {diceSides}");
                Console.WriteLine($"Fixed bonus: {fixedBonus}\n");
                Console.WriteLine($"Command: DiceRoll({numberOfRolls}, {diceSides}, {fixedBonus});\n");
            }

            Console.Write($"Trowing {diceNotation} ... ");

            for (int i = 0; i < numberOfResults; i++) {
                Console.Write($"{DiceRoll(numberOfRolls, diceSides, fixedBonus)} ");
            }

            Console.WriteLine();
        }
    }
}
