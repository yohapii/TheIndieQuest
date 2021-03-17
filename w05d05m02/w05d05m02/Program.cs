using System;
using System.Collections.Generic;
using System.IO;

namespace w05d05m02 {
    class Program {
        static void Main(string[] args) {
            string fileName = "message.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            string readText = File.ReadAllText(path);

            string[] readWords = readText.Split(',', '.', ' ');

            List<string> phoneNumbers = new List<string>();

            for (int i = 0; i < readWords.Length; i++) {
                if (IsPhoneNumber(readWords[i])) {
                    phoneNumbers.Add(readWords[i]);
                }
            }

            Console.WriteLine("The phone numbers present in the file are:");

            for (int i = 0; i < phoneNumbers.Count; i++) {
                Console.WriteLine(phoneNumbers[i]);
            }

            Console.WriteLine();
        }

        static bool IsPhoneNumber(string input) {
            if (input.Length == 12) {
                string[] splitInput = input.Split('-');
                if (splitInput.Length == 3) {
                    if (splitInput[0].Length == 3 && splitInput[1].Length == 3 && splitInput[2].Length == 4) {
                        for (int i = 0; i < splitInput.Length; i++) {
                            for (int j = 0; j < splitInput[i].Length; j++) {
                                if (!Char.IsDigit(splitInput[i][j])) {
                                    return false;
                                }
                            }
                        }
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
