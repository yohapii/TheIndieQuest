/* Objective: Dice roll simulator
Using methods sure makes code easier to be reused, don't you think? Now, if you made a method to simulate dice rolls, we could quickly use it to do all necessary calculations.

We previously used fixed HP numbers for our monsters. Let's use proper random values now (orc has 2d8+6 HP, mage 9d8, and troll 8d10+40).

To make this very easy, write a method DiceRoll with signature:

static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)

Note: because we wrote fixedBonus = 0, we don't need to provide the third parameter in a call unless we need it. It will default to 0, such as for the DiceRoll(9, 8) that you should call to generate Mage's HP.

Once you have the roll method calculating the monsters' HP, you can also use it to calculate greatsword hits (2d6) and saving throws (1d20).

Completion goals:
Write a method DiceRoll that simulates dice rolls and returns the sum of the rolls plus the fixed bonus.
Use the DiceRoll method to calculate monster HPs, greatsword hits, and saving throws.
Rerun your simulation and make sure the numbers appear correct.

Caution: Pay attention especially to setting the correct higher bound in the random method. To test correctness, rerun the simulation to see that damage of 12 appears sometimes.

Example output:
A party of warriors (Jazlyn, Theron, Dayana, Rolando) descends into the dungeon.
Watch out, orc with 13 HP appears!
Jazlyn hits the orc for 6 damage. The orc has 7 HP left.
Theron hits the orc for 8 damage. The orc has 0 HP left.
The orc collapses and the heroes celebrate their victory!
Watch out, mage with 46 HP appears!
Jazlyn hits the mage for 5 damage. The mage has 41 HP left.
Theron hits the mage for 10 damage. The mage has 31 HP left.
Dayana hits the mage for 6 damage. The mage has 25 HP left.
Rolando hits the mage for 8 damage. The mage has 17 HP left.
The mage attacks Dayana!
Dayana rolls a 1 and fails to be saved. Dayana is killed.
Jazlyn hits the mage for 4 damage. The mage has 13 HP left.
Theron hits the mage for 6 damage. The mage has 7 HP left.
Rolando hits the mage for 3 damage. The mage has 4 HP left.
The mage attacks Theron!
Theron rolls a 15 and is saved from the attack.
Jazlyn hits the mage for 4 damage. The mage has 0 HP left.
The mage collapses and the heroes celebrate their victory!
Watch out, troll with 85 HP appears!
Jazlyn hits the troll for 12 damage. The troll has 73 HP left.
Theron hits the troll for 11 damage. The troll has 62 HP left.
Rolando hits the troll for 5 damage. The troll has 57 HP left.
The troll attacks Theron!
Theron rolls a 4 and fails to be saved. Theron is killed.
Jazlyn hits the troll for 7 damage. The troll has 50 HP left.
Rolando hits the troll for 5 damage. The troll has 45 HP left.
The troll attacks Rolando!
Rolando rolls a 6 and fails to be saved. Rolando is killed.
Jazlyn hits the troll for 6 damage. The troll has 39 HP left.
The troll attacks Jazlyn!
Jazlyn rolls a 15 and is saved from the attack.
Jazlyn hits the troll for 8 damage. The troll has 31 HP left.
The troll attacks Jazlyn!
Jazlyn rolls a 18 and is saved from the attack.
Jazlyn hits the troll for 5 damage. The troll has 26 HP left.
The troll attacks Jazlyn!
Jazlyn rolls a 10 and fails to be saved. Jazlyn is killed.
The party has failed and the troll continues to attack unsuspecting adventurers.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w02d05m02 {
    class Program {
        static void Main(string[] args) {
            var rand = new Random();
            for (int i = 0; i < 1; i++) {
                BattleProgram(rand.Next());
            }
        }
        static int DiceRoll(int randomSeed, int numberOfRolls, int diceSides, int fixedBonus = 0) {
            var rand = new Random(randomSeed);
            int result = 0;
            for (int i = 0; i < numberOfRolls; i++) {
                result += rand.Next(1, diceSides + 1);
            }
            return result + fixedBonus;
        }

        static void BattleProgram(int randomSeed) {
            Console.WriteLine("--START OF PROGRAM");
            Console.WriteLine();

            var rand = new Random(randomSeed);
            var partyMembers = new List<string> { "Christ", "Buddha", "Lama", "Drumpf" };
            int partyMembersAmount = partyMembers.Count;
            Console.WriteLine($"A party of warriors ({String.Join(", ", partyMembers)}) descends into the dungeon.");
            var monsterMembers = new List<string> { "orc", "mage", "troll" };
            var monsterMembersHP = new List<int> { DiceRoll(rand.Next(), 2, 8, 6), DiceRoll(rand.Next(), 9, 8), DiceRoll(rand.Next(), 8, 10, 40) };
            var monsterMembersDifficulty = new List<int> { 12, 20, 18 };
            int battleIndex = 0;
            string lastMonster = "";
            while (partyMembers.Count != 0 && battleIndex < monsterMembers.Count) {
                for (; battleIndex < monsterMembers.Count; battleIndex++) {
                    SimulateBattle(randomSeed + battleIndex, partyMembers, monsterMembers[battleIndex], monsterMembersHP[battleIndex], monsterMembersDifficulty[battleIndex]);
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
            var rand = new Random(randomSeed);
            Console.WriteLine($"Watch out, {monster} with {monsterHP} HP appears!");
            while (monsterHP > 0 && partyMembers.Count > 0) {
                for (int i = 0; i < partyMembers.Count && monsterHP > 0; i++) {
                    Console.Write($"{partyMembers[i]} hits the {monster} for ");
                    int damageRoll = DiceRoll(rand.Next(), 2, 6, 0);
                    Console.Write($"{damageRoll} damage. {monster} has ");
                    monsterHP = monsterHP - damageRoll;
                    if (monsterHP < 0) {
                        monsterHP = 0;
                    }
                    Console.WriteLine($"{monsterHP} HP left.");
                }
                if (monsterHP != 0) {
                    int victim = rand.Next(0, partyMembers.Count);
                    Console.WriteLine($"The {monster} attacks {partyMembers[victim]}!");
                    int conResult = DiceRoll(rand.Next(), 1, 20, 5);
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