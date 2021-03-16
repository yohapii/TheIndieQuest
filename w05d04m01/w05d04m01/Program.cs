using System;

namespace w05d04m01 {
    class Program {
        static bool debug = false; // a variable to set if program should print debug lines or not

        static Random rand = new Random();

        static void Main(string[] args) {
            int numberOfResults = 10; // set how many results per throw to show
            int numberOfLoops = 6; // set how many times to loop code

            for (int i = 0; i < numberOfLoops; i++) {
                DiceRoll("d6", numberOfResults);
                DiceRoll("2d4", numberOfResults);
                DiceRoll("d8+12", numberOfResults);
                DiceRoll("2d4-1", numberOfResults);

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
            // convert relevant parts of a correct input string to int
            string[] parts = diceNotation.Split('d', '+', '-');

            int numberOfRolls = 1;
            if (parts[0] != "" && Char.IsDigit(parts[0][0])) {
                numberOfRolls = int.Parse(parts[0].ToString());
            }

            int diceSides = 6;
            if (parts[1] != "" && Char.IsDigit(parts[1][0])) {
                diceSides = int.Parse(parts[1].ToString());
            }

            bool bonusIsPositive = false;
            if (diceNotation.IndexOf('+') > -1) {
                bonusIsPositive = true;
            }

            int fixedBonus = 0;
            if (parts.Length > 2 && parts[2] != "" && Char.IsDigit(parts[2][0])) {
                int parsedBonus = int.Parse(parts[2].ToString());
                if (bonusIsPositive) {
                    fixedBonus = parsedBonus;
                }
                else {
                    fixedBonus -= parsedBonus;
                }
            }

            // Show debug lines if debug variable is set to true
            if (debug) {
                Console.WriteLine($"\n\n--------DEBUG START\n");
                Console.WriteLine($"Dice notation: { diceNotation}\n");
                Console.WriteLine($"parts[0]: {parts[0]}");
                Console.WriteLine($"parts[1]: {parts[1]}");
                if (parts.Length > 2) {
                    Console.WriteLine($"parts[2]: {parts[2]}\n");
                }
                Console.WriteLine($"diceNotation.IndexOf('+'): {diceNotation.IndexOf('+')}");
                Console.WriteLine($"bonusIsPositive: {bonusIsPositive}\n");
                Console.WriteLine($"Number of rolls: {numberOfRolls}");
                Console.WriteLine($"Dice sides: {diceSides}");
                Console.WriteLine($"Fixed bonus: {fixedBonus}\n");
                Console.WriteLine($"Command: DiceRoll({numberOfRolls}, {diceSides}, {fixedBonus});\n");
                Console.WriteLine($"--------DEBUG END\n\n");
            }

            Console.Write($"Trowing {diceNotation} ... ");

            for (int i = 0; i < numberOfResults; i++) {
                Console.Write($"{DiceRoll(numberOfRolls, diceSides, fixedBonus)} ");
            }

            Console.WriteLine();
        }
    }
}
