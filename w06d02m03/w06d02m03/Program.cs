using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace w06d02m03 {

    class Program {
        static void Main(string[] args) {
            string fileName = "MonsterManual.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            string[] readTextLines = File.ReadAllLines(path);

            List<string> monsterNames = new List<string>();
            List<string> monsterAlignments = new List<string>();

            for (int i = 0; i < readTextLines.Length; i++) {
                string sPattern = "(lawful|neutral|chaotic) (good|neutral|evil)";
                if (Regex.IsMatch(readTextLines[i], sPattern)) { // Find line matching the above regular expression
                    monsterNames.Add(readTextLines[i - 1]); // Add name of monster with aligment to list
                    string[] splitSpring = readTextLines[i].Split(','); // Split line so element 1 is the aligment part
                    splitSpring[1] = splitSpring[1].Remove(0, 1); // Remove the first char of alignment part element because it will be a space
                    monsterAlignments.Add(splitSpring[1]); // Add aligment to list of aligments
                }
            }

            Console.WriteLine("Monsters with a specific alignment:");
            for (int i = 0; i < monsterNames.Count; i++) {
                Console.WriteLine($"{monsterNames[i]} ({monsterAlignments[i]})");
            }
            Console.WriteLine();
        }
    }
}
