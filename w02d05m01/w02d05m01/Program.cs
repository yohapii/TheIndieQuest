/* Objective: Battle simulator
Now that you've tested the RPG battle system with the basilisk, let's try it out with 3 new enemies: an orc (15 HP), a mage (40 HP), and a troll (84 HP).

We'll keep things simple and just reuse the code from the basilisk battle, but use a different difficulty class (DC) for the saving throws the heroes need to perform or else be killed. Let's use DC values 12 (orc), 20 (mage), and 18 (troll). And you can give the heroes their greatswords back (2d6 damage).

Your battle simulator should be made as a method with signature:

static void SimulateBattle(List<string> heroes, string monster, int monsterHP, int savingThrowDC) 

Completion goals:
Write the SimulateBattle method by reusing and appropriately adjusting the code from the basilisk battle.
Create the list of heroes and call the SimulateBattle method for all three monsters.
Make sure you do not simulate further battles if all the heroes die.
If they complete all 3 battles, display which heroes survived.

Example output:
A party of warriors (Jazlyn, Theron, Dayana, Rolando) descends into the dungeon.
Watch out, orc with 15 HP appears!
Jazlyn hits the orc for 6 damage. The orc has 9 HP left.
Theron hits the orc for 4 damage. The orc has 5 HP left.
Dayana hits the orc for 6 damage. The orc has 0 HP left.
The orc collapses and the heroes celebrate their victory!
Watch out, mage with 40 HP appears!
Jazlyn hits the mage for 10 damage. The mage has 30 HP left.
Theron hits the mage for 2 damage. The mage has 28 HP left.
Dayana hits the mage for 7 damage. The mage has 21 HP left.
Rolando hits the mage for 8 damage. The mage has 13 HP left.
The mage attacks Jazlyn!
Jazlyn rolls a 1 and fails to be saved. Jazlyn is killed.
Theron hits the mage for 10 damage. The mage has 3 HP left.
Dayana hits the mage for 6 damage. The mage has 0 HP left.
The mage collapses and the heroes celebrate their victory!
Watch out, troll with 84 HP appears!
Theron hits the troll for 9 damage. The troll has 75 HP left.
Dayana hits the troll for 3 damage. The troll has 72 HP left.
Rolando hits the troll for 6 damage. The troll has 66 HP left.
The troll attacks Theron!
Theron rolls a 20 and is saved from the attack.
Theron hits the troll for 6 damage. The troll has 60 HP left.
Dayana hits the troll for 4 damage. The troll has 56 HP left.
Rolando hits the troll for 8 damage. The troll has 48 HP left.
The troll attacks Dayana!
Dayana rolls a 9 and fails to be saved. Dayana is killed.
Theron hits the troll for 8 damage. The troll has 40 HP left.
Rolando hits the troll for 3 damage. The troll has 37 HP left.
The troll attacks Theron!
Theron rolls a 18 and is saved from the attack.
Theron hits the troll for 6 damage. The troll has 31 HP left.
Rolando hits the troll for 6 damage. The troll has 25 HP left.
The troll attacks Rolando!
Rolando rolls a 15 and is saved from the attack.
Theron hits the troll for 9 damage. The troll has 16 HP left.
Rolando hits the troll for 2 damage. The troll has 14 HP left.
The troll attacks Rolando!
Rolando rolls a 9 and fails to be saved. Rolando is killed.
Theron hits the troll for 7 damage. The troll has 7 HP left.
The troll attacks Theron!
Theron rolls a 16 and is saved from the attack.
Theron hits the troll for 3 damage. The troll has 4 HP left.
The troll attacks Theron!
Theron rolls a 18 and is saved from the attack.
Theron hits the troll for 10 damage. The troll has 0 HP left.
The troll collapses and the heroes celebrate their victory!
After three grueling battles, Theron returns from the dungeons. Unfortunately, none of the other party members survived.

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w02d05m01 {
    class Program {
        static void Main(string[] args) {
            var random = new Random();
            for (int i = 0; i < 1; i++) {
                BattleProgram(random.Next());
            }
        }

        static void BattleProgram(int randomSeed) {
            Console.WriteLine("--START OF PROGRAM");
            Console.WriteLine();

            var partyMembers = new List<string> { "Christ", "Buddha", "Lama", "Drumpf" };
            int partyMembersAmount = partyMembers.Count;
            Console.WriteLine($"A party of warriors ({String.Join(", ", partyMembers)}) descends into the dungeon.");
            var monsterMembers = new List<string> { "orc", "mage", "troll" };
            var monsterMembersHP = new List<int> { 15, 40, 84 };
            var monsterMembersDifficulty = new List<int> { 12, 20, 18 };
            int battleIndex = 0;
            string lastMonster = "";
            while (partyMembers.Count != 0 && battleIndex < monsterMembers.Count) {
                for (; battleIndex < monsterMembers.Count; battleIndex++) {
                    SimulateBattle(randomSeed, partyMembers, monsterMembers[battleIndex], monsterMembersHP[battleIndex], monsterMembersDifficulty[battleIndex]);
                    if (partyMembers.Count == 0) {
                        lastMonster = monsterMembers[battleIndex];
                        battleIndex = monsterMembers.Count;
                    }
                }
            }
            string amountInLetters = "";
            NumbersToLetters(monsterMembers.Count, out amountInLetters);
            if (partyMembers.Count == 0) {
                Console.WriteLine($"The party has failed and the {lastMonster} continues to attack unsuspecting adventurers.");
            }
            else if (partyMembers.Count == 1) {
                Console.WriteLine($"After {amountInLetters} grueling battles, {partyMembers[0]} returns from the dungeons. Unfortunately, none of the other party members survived.");
            }
            else if (partyMembers.Count < partyMembersAmount) {
                Console.WriteLine($"After {amountInLetters} grueling battles, the party returns from the dungeons. Unfortunately, there were some casualties.");
            }
            else {
                Console.WriteLine($"After {amountInLetters} easy-peasy battles, the party returns from the dungeons. They go and have some beer.");
            }

            Console.WriteLine();
            Console.WriteLine("--END OF PROGRAM");
        }

        static void SimulateBattle(int randomSeed, List<string> partyMembers, string monster, int monsterHP, int difficulty) {
            var dice = new Random(randomSeed);
            Console.WriteLine($"Watch out, {monster} with {monsterHP} HP appears!");
            while (monsterHP > 0 && partyMembers.Count > 0) {
                for (int i = 0; i < partyMembers.Count && monsterHP > 0; i++) {
                    Console.Write($"{partyMembers[i]} hits the {monster} for ");
                    int damageRoll = 0;
                    for (int j = 0; j < 2; j++) {
                        damageRoll = damageRoll + dice.Next(1, 7);
                    }
                    Console.Write($"{damageRoll} damage. {monster} has ");
                    monsterHP = monsterHP - damageRoll;
                    if (monsterHP < 0) {
                        monsterHP = 0;
                    }
                    Console.WriteLine($"{monsterHP} HP left.");

                }
                if (monsterHP != 0) {
                    int victim = dice.Next(0, partyMembers.Count);
                    Console.WriteLine($"The {monster} attacks {partyMembers[victim]}!");
                    int conResult = dice.Next(1, 21) + 5;
                    Console.Write($"{partyMembers[victim]} rolls a {conResult} ");
                    if (conResult >= difficulty) {
                        Console.WriteLine($"and is saved from the attack.");
                    }
                    else {
                        Console.WriteLine($"and fails to be saved. {partyMembers[victim]} is killed.");
                        partyMembers.Remove(partyMembers[victim]);
                    }
                }
                else {
                    string pluralOrSingular = "heroes";
                    if (partyMembers.Count == 1) {
                        pluralOrSingular = "hero";
                    }
                    Console.WriteLine($"The {monster} collapses and the {pluralOrSingular} celebrate their victory!");
                }
            }
        }

        static void NumbersToLetters(int inputNumber, out string amountInLetters) {
            if (inputNumber == 1) {
                amountInLetters = "one";
            }
            else if (inputNumber == 2) {
                amountInLetters = "two";
            }
            else if (inputNumber == 3) {
                amountInLetters = "three";
            }
            else if (inputNumber == 4) {
                amountInLetters = "four";
            }
            else if (inputNumber == 5) {
                amountInLetters = "five";
            }
            else if (inputNumber == 6) {
                amountInLetters = "six";
            }
            else {
                amountInLetters = inputNumber.ToString();
            }
        }
    }
}