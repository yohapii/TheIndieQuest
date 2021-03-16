using System;

namespace w05d04m03 {
    class Program {
        static bool debug = false; // a variable to set if program should print debug lines or not

        static void Main(string[] args) {

            string textToTest = "To use the magic potion of dragon breath, first roll d8. If you roll 2 or higher, you manage to open the potion. Now roll 5d4+5 to see how many seconds the spell will last. Finally, the damage of the flames will be 2d6 per second.";

            string[] words = textToTest.Split(' ', '.', ',', ';', ':');

            int numberOfDiceNotations = 0;
            int numberOfRolls = 0;
            for (int i = 0; i < words.Length; i++) {
                if (IsStandardDiceNotation(words[i])) {
                    numberOfDiceNotations++;

                    string[] parts = MakeStringArray(words[i]);
                    if (parts[0] == "") {
                        numberOfRolls++;
                    }
                    else {
                        numberOfRolls += int.Parse(parts[0].ToString());
                    }
                }
            }

            Console.WriteLine($"Text to test:\n-------------");
            Console.WriteLine($"{textToTest}");
            Console.WriteLine($"-------------\n");
            Console.WriteLine($"{numberOfDiceNotations} standard dice notations present.");
            Console.WriteLine($"The player will have to perform {numberOfRolls} rolls.\n\n");
        }

        static string[] MakeStringArray(string input) {
            return input.Split('d', '+', '-');
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
