/*
 Objective: Battle with the basilisk
Part 1
It's time to battle! Forget about the gelatinous cubes though, our party will face a basilisk. You know, the one that can turn you into stone? And to make things easier, let's start with a party of four warriors equipped with greatswords.

Completion goals:
Create a party of four warriors and add their names to a list of strings. Output the description of the party.
Create a basilisk with random HP (8d8+16) and output a description.
Hit the basilisk with a greatsword (2d6 damage) by each hero and output how much damage they have done and how much HP the basilisk has left.

Example output:
A party of warriors (Jazlyn, Theron, Dayana, Rolando) descends into the dungeon.
A basilisk with 51 HP appears!
Jazlyn hits the basilisk for 12 damage. Basilisk has 39 HP left.
Theron hits the basilisk for 3 damage. Basilisk has 36 HP left.
Dayana hits the basilisk for 8 damage. Basilisk has 28 HP left.
Rolando hits the basilisk for 7 damage. Basilisk has 21 HP left.

Hint: You can use Console.Write instead of WriteLine to output a line partially. An empty Console.WriteLine() can then go to a new line. Alternatively, create a string variable and build it up piece by piece with concatenation or interpolation.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w02d04m02 {
    class Program {
        static void Main(string[] args) {
            var random = new Random();
            for (int i = 0; i < 1; i++) {
                basiliskBattle(random.Next());
            }
        }

        static void basiliskBattle(int randomSeed) {
            var dice = new Random(randomSeed);
            var partyMembers = new List<string> { "J. Christ", "The Buddha", "D. Lama", "D. J. Drumpf" };
            Console.WriteLine($"A party of warriors ({String.Join(", ", partyMembers)}) descends into the dungeon.");
            var basiliskHP = 16;
            for (int i = 0; i < 8; i++) {
                int roll = dice.Next(1, 9);
                basiliskHP = basiliskHP + roll;
            }
            Console.WriteLine($"A basilisk with {basiliskHP} HP appears!");
            for (int i = 0; i < partyMembers.Count; i++) {
                Console.Write($"{partyMembers[i]} hits the basilisk for ");
                int damageRoll = 0;
                for (int ii = 0; ii < 2; ii++) {
                    damageRoll = damageRoll + dice.Next(1, 7);
                }
                Console.Write($"{damageRoll} damage. Basilisk has ");
                basiliskHP = basiliskHP - damageRoll;
                Console.WriteLine($"{basiliskHP} HP left.");

            }

            Console.WriteLine();
            Console.WriteLine("--END OF PROGRAM");
        }
    }
}
