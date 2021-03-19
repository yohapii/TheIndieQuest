using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace w06d01m03 {
    class Program {
        static void Main(string[] args) {
            string fileName = "MonsterManual.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            string[] readTextLines = File.ReadAllLines(path);

            List<string> monsterNames = new List<string>();
            List<bool> monsterHighNumberOfRolls = new List<bool>();

            for (int i = 0; i < readTextLines.Length; i++) {
                if (i == 0 || readTextLines[i - 1] == "") {
                    monsterNames.Add(readTextLines[i]);
                }

                string sPattern = "Hit Points:";
                if (Regex.IsMatch(readTextLines[i], sPattern)) {
                    sPattern = @"\d{2,}d";
                    if (Regex.IsMatch(readTextLines[i], sPattern)) {
                        monsterHighNumberOfRolls.Add(true);
                    }
                    else {
                        monsterHighNumberOfRolls.Add(false);
                    }
                }
            }

            Console.WriteLine("Monsters in the manual are:");
            for (int i = 0; i < monsterNames.Count; i++) {
                Console.WriteLine($"{monsterNames[i]} - 10+ dice rolls: {monsterHighNumberOfRolls[i]}");
            }
            Console.WriteLine();
        }
    }
}
