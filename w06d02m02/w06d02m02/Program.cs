using System;
using System.Text.RegularExpressions;

namespace w06d02m02 {
    class Program {
        static Random rand = new Random();

        static void Main(string[] args) {
            int numberOfResults = 10; // set how many results per throw to show
            int numberOfLoops = 5; // set how many times to loop code

            for (int i = 0; i < numberOfLoops; i++) {
                DiceRoll("2d6", numberOfResults);
                DiceRoll("d20", numberOfResults);
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
            string sPattern = @"^\d*d\d+([+-]\d+)?$";
            if (Regex.IsMatch(input, sPattern)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
