/* Objective: Generate characters, 5th edition
We like the work you did yesterday on character generation, but our designers figured it's time to ditch 2nd edition D&D and go to the latest ruleset. In 5th edition, instead of rolling 3d6 and being stuck with whatever ability scores you got, the player has much more freedom. Here's how it works:

To get an ability score, you roll 4d6 and sum the highest 3 dice rolls. So if you roll 5, 2, 4, and 3, the 2 will be discarded and the score would be 5 + 4 + 3 = 12.

Now repeat this 6 times to get 6 ability scores. Instead of rolling for specific abilities in a row (strength, intelligence, dexterity …), the player gets to choose which score they will assign to which ability. We want to show the scores from lowest to highest so it's easiest to choose which score goes where.

Completion goals:
Calculate 6 ability scores by summing the highest 3 out of 4 rolls for each score. Display the information about the rolls.
Present a sorted list of ability scores.

Example output:
You roll 6, 3, 4, 5. The ability score is 15.
You roll 6, 5, 6, 4. The ability score is 17.
You roll 5, 6, 5, 1. The ability score is 16.
You roll 6, 5, 1, 5. The ability score is 16.
You roll 3, 5, 1, 1. The ability score is 9.
You roll 2, 6, 2, 6. The ability score is 14.
Your available ability scores are 9, 14, 15, 16, 16, 17.

Caution: You have to add using System.Collections.Generic; line to the top of your file to be able to use generic collections. Visual Studio should give you a suggestion to do this whenever you use a class that is not accessible directly in the System namespace.

Hint: You can convert a list to a string by using the String.Join method, for example, String.Join(", ", rolls) will add a comma between them like in the above examples.

Hint: The easiest way to find the lowest or highest numbers in a collection is to sort them. */


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
                GenerateCharacters(random.Next());
            }
        }
        static void GenerateCharacters(int randomSeed) {
            var dice = new Random(randomSeed);
            var summedRolls = new List<int> { };
            for (int i = 0; i < 6; i++) {
                var rolls = new List<int> { };
                for (int ii = 0; ii < 4; ii++) {
                    int roll = dice.Next(1, 7);
                    rolls.Add(roll);
                }
                Console.Write($"You roll {String.Join(", ", rolls)}. The ability score is ");
                rolls.Sort();
                rolls.Remove(rolls[0]);
                int sumOfRolls = 0;
                foreach (var roll in rolls) {
                    sumOfRolls = sumOfRolls + roll;
                }
                Console.WriteLine($"{sumOfRolls}.");
                summedRolls.Add(sumOfRolls);
            }
            summedRolls.Sort();
            Console.WriteLine($"Your available ability scores are {String.Join(", ", summedRolls)}.");

            Console.WriteLine();
            Console.WriteLine("--END OF PROGRAM");
        }

    }
}

