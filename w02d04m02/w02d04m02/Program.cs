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

Part 2
Did you see that blow Jazlyn did? Badass! But we can't stop yet, the basilisk is still around. Make the heroes keep hitting it (one after the other) until it's dead.

Completion goals:
Repeat the round of heroes' attacks until the basilisk has 0 HP (note that negative hit points aren't allowed so account for that).
Make sure the heroes don't attack after the basilisk is dead. 
Output a happy ending narrative.

Example output:
A party of warriors (Jazlyn, Theron, Dayana, Rolando) descends into the dungeon.
A basilisk with 50 HP appears!
Jazlyn hits the basilisk for 10 damage. Basilisk has 40 HP left.
Theron hits the basilisk for 5 damage. Basilisk has 35 HP left.
Dayana hits the basilisk for 12 damage. Basilisk has 23 HP left.
Rolando hits the basilisk for 8 damage. Basilisk has 15 HP left.
Jazlyn hits the basilisk for 10 damage. Basilisk has 5 HP left.
Theron hits the basilisk for 9 damage. Basilisk has 0 HP left.
The basilisk collapses and the heroes celebrate their victory!

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
            var partyMembers = new List<string> { "Christ", "Buddha", "Lama", "Drumpf" };
            Console.WriteLine($"A party of warriors ({String.Join(", ", partyMembers)}) descends into the dungeon.");
            var basiliskHP = 16;
            for (int i = 0; i < 8; i++) {
                int roll = dice.Next(1, 9);
                basiliskHP = basiliskHP + roll;
            }
            Console.WriteLine($"A basilisk with {basiliskHP} HP appears!");
            while (basiliskHP > 0) {
                for (int i = 0; i < partyMembers.Count && basiliskHP > 0; i++) {
                    Console.Write($"{partyMembers[i]} hits the basilisk for ");
                    int damageRoll = 0;
                    for (int ii = 0; ii < 2; ii++) {
                        damageRoll = damageRoll + dice.Next(1, 7);
                    }
                    Console.Write($"{damageRoll} damage. Basilisk has ");
                    basiliskHP = basiliskHP - damageRoll;
                    if (basiliskHP < 0) {
                        basiliskHP = 0;
                    }
                    Console.WriteLine($"{basiliskHP} HP left.");

                }
            }
            Console.WriteLine($"The basilisk collapses and the heroes celebrate their victory!");

            Console.WriteLine();
            Console.WriteLine("--END OF PROGRAM");
        }
    }
}
