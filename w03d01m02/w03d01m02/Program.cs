/* Objective: A better Join
A teammate on the RPG project approaches you next:

Lovely work on the battle simulation last week. The narrative designer wants us to improve something though. You know how we join a list of heroes' names with a comma?  

String.Join(", ", heroes);

Well, it would read better if there was an "and" in there too. So instead of Jazlyn, Theron, Dayana, Rolando it'd be Jazlyn, Theron, Dayana, and Rolando. Actually I don't know if we want that serial comma (https://en.wikipedia.org/wiki/Serial_comma) before "and" (probably we do), so let's make a helper method that can handle it all. Something like:

static string JoinWithAnd(List<string> items, bool useSerialComma = true)

The details are a bit complicated depending on how many items you get in the array, so I sketched it out for you with a flowchart (https://www.bbc.co.uk/bitesize/guides/z7kkw6f/revision/3):
https://i.imgur.com/BYxCEWs.png

Completion goals:
1. Read Page 3 of the Algorithms article: Flowcharts (https://www.bbc.co.uk/bitesize/guides/z7kkw6f/revision/3).
2. Implement the above program in C#.

Example outputs (with serial comma and without):
The heroes in the party are: Jazlyn, Theron, Dayana, and Rolando.
The heroes in the party are: Theron, Dayana, and Rolando.
The heroes in the party are: Dayana and Rolando.
The heroes in the party are: Rolando.
—
The heroes in the party are: Jazlyn, Theron, Dayana and Rolando.
The heroes in the party are: Theron, Dayana and Rolando.
The heroes in the party are: Dayana and Rolando.
The heroes in the party are: Rolando.

Hint: You can create a copy of a list by creating a new list and passing the old list to the constructor like so: var itemsCopy = new List<string>(items);

Hint: You can remove an item at a specified index from a list with the RemoveAt method.

Caution: The last item in a list has the index count - 1 since the indices start at 0.
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace w03d01m02 {
    class Program {
        static void Main(string[] args) {
            var items = new List<string> { "Christ", "Buddha", "Lama", "Drumpf", "Jan", "Newnorth", "Cederholm" };

            Console.WriteLine($"With serial comma:");

            var itemsCopy = new List<string>(items);
            var count = itemsCopy.Count;

            for (int i = 0; i < count; i++) {
                Console.WriteLine($"The heroes in the party are: {JoinWithAnd(itemsCopy)}.");
                itemsCopy.RemoveAt(itemsCopy.Count - 1);
            }

            Console.WriteLine($"--");
            Console.WriteLine($"Without serial comma:");

            itemsCopy = new List<string>(items);
            count = itemsCopy.Count;

            for (int i = 0; i < count; i++) {
                Console.WriteLine($"The heroes in the party are: {JoinWithAnd(itemsCopy,false)}.");
                itemsCopy.RemoveAt(itemsCopy.Count - 1);
            }

            Console.WriteLine($"--");
        }
        static string JoinWithAnd(List<string> items, bool useSerialComma = true) {
            var count = items.Count;

            if (count == 0) {
                return "";
            }
            else if (count == 1) {
                return items[0];
            }
            else if (count == 2) {
                return String.Join(" and ", items);
            }
            else {
                var itemsCopy = new List<string>(items);

                if (useSerialComma == true) {
                    itemsCopy[itemsCopy.Count - 1] = "and " + itemsCopy[itemsCopy.Count - 1];
                    return String.Join(", ",itemsCopy);
                }
                else {
                    itemsCopy[itemsCopy.Count - 2] += " and " + itemsCopy[itemsCopy.Count - 1];
                    itemsCopy.RemoveAt(itemsCopy.Count - 1);
                    return String.Join(", ", itemsCopy);
                }
            }
        }
    }
}
