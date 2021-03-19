using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace w06d01m04 {
    class Program {
        static void Main(string[] args) {
            string fileName = "MonsterManual.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            string[] readTextLines = File.ReadAllLines(path);

            List<string> monsterNames = new List<string>();
            List<bool> monstersFlyTenToForty = new List<bool>();

            for (int i = 0; i < readTextLines.Length; i++) {
                if (i == 0 || readTextLines[i - 1] == "") {
                    monsterNames.Add(readTextLines[i]);
                }

                string sPattern = "Speed:";
                if (Regex.IsMatch(readTextLines[i], sPattern)) {
                    sPattern = @"fly [1-4]";
                    if (Regex.IsMatch(readTextLines[i], sPattern)) {
                        monstersFlyTenToForty.Add(true);
                    }
                    else {
                        monstersFlyTenToForty.Add(false);
                    }
                }
            }

            Console.WriteLine("Monsters that can fly 10-40 feet per turn:");
            for (int i = 0; i < monsterNames.Count; i++) {
                if (monstersFlyTenToForty[i]) {
                    Console.WriteLine($"{monsterNames[i]}");
                }
            }
            Console.WriteLine();
        }
    }
}
