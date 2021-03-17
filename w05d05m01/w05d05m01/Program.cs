using System;

namespace w05d05m01 {
    class Program {
        static bool debug = false; // a variable to set if program should print debug lines or not

        static Random rand = new Random();

        static void Main(string[] args) {
            int numberOfResults = 10; // set how many results per throw to show
            int numberOfLoops = 1; // set how many times to loop code
            string[] diceNotation = { "d6", "2d4", "d8+12", "2d4-1", "2d6", "34", "-12", "ad6", "-3d6", "0d6", "d+", "2d-4", "2d2.5", "2d$" };

            for (int i = 0; i < numberOfLoops; i++) {
                for (int j = 0; j < diceNotation.Length; j++) {
                    try {
                        int testThrow = DiceRoll(diceNotation[j]);

                        Console.Write($"Trowing {diceNotation[j]} ... ");

                        for (int k = 0; k < numberOfResults; k++) {
                            Console.Write($"{DiceRoll(diceNotation[j])} ");
                        }

                        Console.WriteLine();
                    }
                    catch (Exception error) {
                        Console.WriteLine($"Can't throw {diceNotation[j]} ... {error.Message}");
                    }
                }
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

        static string[] MakeStringArray(string input) {
            return input.Split('d', '+', '-');
        }

        static int DiceRoll(string diceNotation) {
            // splits up diceNotation in an array
            string[] parts = MakeStringArray(diceNotation);

            // ----- START OF ERROR CHECKING ----- //

            string errorMessage;

            // checks if there is no d present in there (there must)
            if (diceNotation.IndexOf('d') == -1) {
                errorMessage = "Roll description is not in standard dice notation.";
                throw new ArgumentException(errorMessage);
            }

            // checks if there are 4 or more elements, since only 2 or 3 allowed
            if (parts.Length > 3) {
                errorMessage = "Too many elements.";
                throw new ArgumentException(errorMessage);
            }

            if (parts.Length > 2) {
                // checks if there is no + or - present, since there are 3 or more elements
                if (diceNotation.IndexOf('+') == -1 && diceNotation.IndexOf('-') == -1) {
                    errorMessage = "No + or - present.";
                    throw new ArgumentException(errorMessage);
                }
            }

            // the rest of error checking code checks specific elements if they are non-ints or negative
            int testInt;
            string[] testSplit = diceNotation.Split('d');

            // Dice sides
            try {
                testInt = Int32.Parse(parts[1]);
            }
            catch {
                errorMessage = $"Number of dice sides ({parts[1]}) is not an integer.";
                throw new ArgumentException(errorMessage);
            }
            if (testSplit[1][0] == '-' || Int32.Parse(parts[1]) == 0) {
                errorMessage = $"Number of dice sides ({testSplit[1]}) has to be positive.";
                throw new ArgumentException(errorMessage);
            }

            // Number of rolls
            if (testSplit[0] != "") {
                try {

                    testInt = Int32.Parse(testSplit[0]);

                }
                catch {
                    errorMessage = $"Number of rolls ({testSplit[0]}) is not an integer.";
                    throw new ArgumentException(errorMessage);
                }
                if (testSplit[0].Contains("-") || Int32.Parse(parts[0]) == 0) {
                    errorMessage = $"Number of rolls ({testSplit[0]}) has to be positive.";
                    throw new ArgumentException(errorMessage);
                }
            }

            // ------ END OF ERROR CHECKING ------ //


            // convert relevant parts of a correct diceNotation to ints

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
            }

            return DiceRoll(numberOfRolls, diceSides, fixedBonus);
        }
    }
}
