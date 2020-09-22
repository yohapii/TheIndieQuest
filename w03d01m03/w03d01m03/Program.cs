/* Objective: Ordinal numbers
Just before the coworker leaves they say:

Oh, another useful method would be to convert integers into ordinal numbers. I don't have time to fully flesh out the code, but basically do:

1. Get the last digit of an integer by modding it with 10.
2. If the number is bigger than 10, also get the second to last digit by dividing the integer by 10 and then modding the result with 10.
3. If the second to last digit is 1, return the integer plus "th"
4. If the last digit is 1, return the integer plus "st".
5. If the last digit is 2, return the integer plus "nd".
6. If the last digit is 3, return the integer plus "rd".
7. Otherwise return integer plus "th".

OK, gotta go!

Completion goals:
1. Read Page 4 of the Algorithms article: Written descriptions. https://www.bbc.co.uk/bitesize/guides/z7kkw6f/revision/4
2. Implement the method static string OrdinalNumber(int number) in C#.

Example output:
1st
2nd
3rd
4th
10th
11th
12th
13th
21st
101st
111th
121st

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w03d01m03 {
    class Program {
        static void Main(string[] args) {
            for (int i = 0; i <= 128; i++) {
                Console.WriteLine($"{OrdinalNumber(i)}");
            }
        }

        static string OrdinalNumber(int number) {
            int lastDigit = number % 10;
            int secondToLastDigit = 0;

            if (number >= 10) {
                secondToLastDigit = number / 10 % 10;
            }
            if (secondToLastDigit == 1) {
                return number + "th";
            }
            if (lastDigit == 1) {
                return number + "st";
            }
            if (lastDigit == 2) {
                return number + "nd";
            }
            if (lastDigit == 3) {
                return number + "rd";
            }
            if (number == 0) {
                return "Zero";
            }
            return number + "th";
        }
    }
}
