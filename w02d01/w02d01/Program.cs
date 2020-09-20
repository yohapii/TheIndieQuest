using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w02d01 {
    class Program {
        static void Main(string[] args) {
            // Mission 1:
            string playerName = "Johannes";
            Console.WriteLine($"Welcome to Dungeon World, {playerName}! We call upon you to oversee a team of adventurers in a series of battles that will decide the fate of the world itself!");
            Console.WriteLine($"--");

            // Mission 2:
            string warriorName = "B1";
            string mageName = "B2";
            string dialogue = "The party stared down the stone stairs into darkness. \"We should've brought some torches with us,\" remarked WARRIOR. MAGE turned around and replied, \"Worry not dear WARRIOR, let me shine some light for you,\" as she cast a Continual light spell.";
            dialogue = dialogue.Replace("WARRIOR", warriorName);
            dialogue = dialogue.Replace("MAGE", mageName);
            Console.WriteLine(dialogue);
            Console.WriteLine($"--");

            // Mission 3:
            string windowsTrue = System.Environment.OSVersion.VersionString;
            Console.WriteLine($"You are running the game on Windows: {windowsTrue.Contains("Windows")}");
        }
    }
}
