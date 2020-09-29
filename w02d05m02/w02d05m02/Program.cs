/* Objective: Battle with the basilisk
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

Part 3
As cool as that was, it wasn't really a fair fight. It's time for the basilisk to strike back and use its petrifying gaze ability.

The character has a chance to save themself from the attack. In particular, they do a DC 12 Constitution saving throw. To do a Constitution saving throw you roll d20 and add the constitution ability score to it. DC means difficulty class and the saving throw needs to be at least DC or higher. 

To make things simple, let's assume all our characters have constitution 5 (they're weaklings, OK?). If they roll a 7, 7 + 5 = 12 and they get saved. If they roll a 6, 6 + 5 = 11, which is lower than the DC 12 required for a save, they get turned into stone!

Oh yeah, let's make things even harder by removing the great swords and giving our puny heroes daggers instead.

Completion goals:
Replace hit calculations to use daggers (1d4 damage).
After each round of heroes' attacks, the basilisk uses petrifying gaze on a random hero. Display who it is.
The hero has to pass a DC 12 constitution saving throw to survive. Assume they have constitution 5, add a d20 roll, and check if the total is 12 or higher. Display the roll amount and if they succeed to be saved.
If they don't succeed, display that they got turned into stone and remove them from the list of heroes.
If all heroes get turned into stone before they defeat the basilisk, the game is over. Display a bad ending narrative.

Example output:
A party of warriors (Jazlyn, Theron, Dayana, Rolando) descends into the dungeon.
A basilisk with 45 HP appears!
Jazlyn hits the basilisk for 2 damage. Basilisk has 43 HP left.
Theron hits the basilisk for 1 damage. Basilisk has 42 HP left.
Dayana hits the basilisk for 2 damage. Basilisk has 40 HP left.
Rolando hits the basilisk for 1 damage. Basilisk has 39 HP left.
The basilisk uses petrifying gaze on Rolando!
Rolando rolls a 6 and fails to be saved. Rolando is turned into stone.
Jazlyn hits the basilisk for 4 damage. Basilisk has 35 HP left.
Theron hits the basilisk for 4 damage. Basilisk has 31 HP left.
Dayana hits the basilisk for 2 damage. Basilisk has 29 HP left.
The basilisk uses petrifying gaze on Theron!
Theron rolls a 4 and fails to be saved. Theron is turned into stone.
Jazlyn hits the basilisk for 2 damage. Basilisk has 27 HP left.
Dayana hits the basilisk for 4 damage. Basilisk has 23 HP left.
The basilisk uses petrifying gaze on Dayana!
Dayana rolls a 20 and is saved from the attack.
Jazlyn hits the basilisk for 2 damage. Basilisk has 21 HP left.
Dayana hits the basilisk for 2 damage. Basilisk has 19 HP left.
The basilisk uses petrifying gaze on Jazlyn!
Jazlyn rolls a 12 and is saved from the attack.
Jazlyn hits the basilisk for 1 damage. Basilisk has 18 HP left.
Dayana hits the basilisk for 1 damage. Basilisk has 17 HP left.
The basilisk uses petrifying gaze on Jazlyn!
Jazlyn rolls a 1 and fails to be saved. Jazlyn is turned into stone.
Dayana hits the basilisk for 4 damage. Basilisk has 13 HP left.
The basilisk uses petrifying gaze on Dayana!
Dayana rolls a 17 and is saved from the attack.
Dayana hits the basilisk for 3 damage. Basilisk has 10 HP left.
The basilisk uses petrifying gaze on Dayana!
Dayana rolls a 12 and is saved from the attack.
Dayana hits the basilisk for 2 damage. Basilisk has 8 HP left.
The basilisk uses petrifying gaze on Dayana!
Dayana rolls a 5 and fails to be saved. Dayana is turned into stone.
The party has failed and the basilisk continues to turn unsuspecting adventurers to stone.

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w02d05m02 {
    class Program {
        static void Main(string[] args) {
            var random = new Random();
            for (int i = 0; i < 1; i++) {
                basiliskBattle(random.Next());
            }
        }

        static void basiliskBattle(int randomSeed) {
            Console.WriteLine("--START OF PROGRAM");
            Console.WriteLine();

            var dice = new Random(randomSeed);
            var partyMembers = new List<string> { "Christ", "Buddha", "Lama", "Drumpf" };
            Console.WriteLine($"A party of warriors ({String.Join(", ", partyMembers)}) descends into the dungeon.");
            var basiliskHP = 16;
            for (int i = 0; i < 8; i++) {
                int roll = dice.Next(1, 9);
                basiliskHP = basiliskHP + roll;
            }
            Console.WriteLine($"A basilisk with {basiliskHP} HP appears!");
            while (basiliskHP > 0 && partyMembers.Count > 0) {
                for (int i = 0; i < partyMembers.Count && basiliskHP > 0; i++) {
                    Console.Write($"{partyMembers[i]} hits the basilisk for ");
                    int damageRoll = 0;
                    damageRoll = damageRoll + dice.Next(1, 5); // 1d4 according to Part 3

                    /*
                    // 2d6 according to Part 2:
                    for (int ii = 0; ii < 2; ii++) {
                        damageRoll = damageRoll + dice.Next(1, 7);
                    }
                    */

                    Console.Write($"{damageRoll} damage. Basilisk has ");
                    basiliskHP = basiliskHP - damageRoll;
                    if (basiliskHP < 0) {
                        basiliskHP = 0;
                    }
                    Console.WriteLine($"{basiliskHP} HP left.");

                }
                if (basiliskHP != 0) {
                    int victim = dice.Next(0, partyMembers.Count);
                    Console.WriteLine($"The basilisk uses petrifying gaze on {partyMembers[victim]}!");
                    int conResult = dice.Next(1, 21) + 5;
                    if (conResult >= 12) {
                        Console.WriteLine($"{partyMembers[victim]} rolls a {conResult} and is saved from the attack.");
                    }
                    else {
                        Console.WriteLine($"{partyMembers[victim]} rolls a {conResult} and fails to be saved. {partyMembers[victim]} is turned into stone.");
                        partyMembers.Remove(partyMembers[victim]);
                    }
                }
            }
            if (partyMembers.Count == 0) {
                Console.WriteLine($"The party has failed and the basilisk continues to turn unsuspecting adventurers to stone.");
            }
            else {
                Console.WriteLine($"The basilisk collapses and the heroes celebrate their victory!");
            }

            Console.WriteLine();
            Console.WriteLine("--END OF PROGRAM");
        }
    }
}
