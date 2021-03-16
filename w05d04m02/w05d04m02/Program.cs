using System;

namespace w05d04m02 {
    class Program {
        static bool debug = false; // a variable to set if program should print debug lines or not

        static Random rand = new Random();

        static void Main(string[] args) {
            int numberOfResults = 10; // set how many results per throw to show
            int numberOfLoops = 5; // set how many times to loop code

            for (int i = 0; i < numberOfLoops; i++) {
                DiceRoll("2d6", numberOfResults);
                DiceRoll("d8+12", numberOfResults);
                DiceRoll("34", numberOfResults);
                DiceRoll("ad6", numberOfResults);
                DiceRoll("33d4*8", numberOfResults);
                DiceRoll("7+1d6", numberOfResults);

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

        static void DiceRoll(string diceNotation, int numberOfResults) {
            if (IsStandardDiceNotation(diceNotation)) {
                // convert relevant parts of a correct input string to int
                string[] parts = MakeStringArray(diceNotation);

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

                Console.Write($"Trowing {diceNotation} ... ");

                for (int i = 0; i < numberOfResults; i++) {
                    Console.Write($"{DiceRoll(numberOfRolls, diceSides, fixedBonus)} ");
                }

                Console.WriteLine();
            }
            else {
                Console.WriteLine($"Can't throw {diceNotation}, it is not in standard dice notation.");
            }
        }

        static bool IsStandardDiceNotation(string input) {
            // checks if there is no d present in there (there must)
            if (input.IndexOf('d') == -1) {
                if (debug) { Console.WriteLine($"\nNo 'd' present."); }
                return false;
            }

            // splits up input in an array
            string[] splitInput = MakeStringArray(input);

            // checks if there are 4 or more elements, since only 2 or 3 allowed
            if (splitInput.Length > 3) {
                if (debug) { Console.WriteLine($"\nToo many elements."); }
                return false;
            }

            if (splitInput.Length > 2) {
                // checks if there is no + or - present, since there are 3 or more elements
                if (input.IndexOf('+') == -1 && input.IndexOf('-') == -1) {
                    if (debug) { Console.WriteLine($"\nNo + or - present."); }
                    return false;
                }
                // checks if + or - is before the d, which is not allowed
                else if (input.IndexOf('-') == -1 && input.IndexOf('+') < input.IndexOf('d') || input.IndexOf('+') == -1 && input.IndexOf('-') < input.IndexOf('d')) {
                    if (debug) { Console.WriteLine($"\n+ or - is before 'd'."); }
                    return false;
                }
            }

            // checks that the content of elements are valid digits
            string inputElement;
            for (int i = 0; i < splitInput.Length; i++) {
                inputElement = splitInput[i];

                for (int j = 0; j < inputElement.Length; j++) {
                    if (!Char.IsDigit(inputElement[j])) {
                        if (debug) { Console.WriteLine($"\nNon-digit detected."); }
                        return false;
                    }
                }
            }

            if (debug) { Console.WriteLine($"\nValid dice notation."); }
            return true;
        }
    }
}
