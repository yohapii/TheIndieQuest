using System;
using System.Collections.Generic;
using System.IO;

namespace w06d01m01 {
    class Program {
        static void Main(string[] args) {
            string fileName = "MonsterManual.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            string[] readTextLines = File.ReadAllLines(path);

            List<string> monsterNames = new List<string>();

            for (int i = 0; i < readTextLines.Length; i++) {
                if (i == 0 || readTextLines[i - 1] == "") {
                    monsterNames.Add(readTextLines[i]);
                }
            }

            Console.WriteLine("Monsters in the manual are:");
            Console.WriteLine($"{string.Join("\n", monsterNames)}");
            Console.WriteLine();
        }
    }
}
