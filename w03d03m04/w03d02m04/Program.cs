/* Objective: The Matrix
It's lunch time and you go eat with some of the coworkers. The conversation finds its way to favorite movies and one of the programmers mentions The Matrix (https://en.wikipedia.org/wiki/The_Matrix). They remember they wrote a screensaver that displayed the code like in the movie. While waiting for everyone to finish their meal, they write down how they remember the program worked.

var streams = new List<int>
var symbols = "!@#$%^&*()_+-=[];',.\/~{}:|<>?";

for (i = 0; i < 10; i++) streams.Add(random.Next(0, 80));

Console.ForegroundColor = ConsoleColor.DarkGren;

while (true)
{
    for (int x = 0; x < 80; x++)
    {
        Console.Write(streams.Contains(x) ? symbols[random.Next(symbols.Length)] : ' ';
    }

    Console.WriteLine();
    Thread.Sleep(100)

    if (random.Next(3) = 0) streams.RemoveAt(random.Next(streams.Count));
    if (random.Next(3) = 0) streams.Add(random.Next(0, 80));

You want to see how it looked, so when you get to your computer, you type it into a new console application. It's not exactly working code, but it should be good enough with a few fixes.

(completion goals are listed on the next page)


Completion goals:
1. Read Page 5 of the Algorithms article: Program code. https://www.bbc.co.uk/bitesize/guides/z7kkw6f/revision/5
2. Fix the code to see the screensaver.

Hint: The character \ inside a string variable has a special meaning as it indicates a start of an escape sequence (https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=vs-2019). For example, a special combination such as \t can be used to output a tab character, or \" can output a quotation mark (since using just " would instead end the string). To output a backslash character itself (as was intended by the programmer), you use the \\ sequence.

Hint: An alternative to using the escape sequence \\ is to disable escape sequences in the first place by using the @ sign in front of the string. This makes a so-called verbatim string where the character \ simply means the backslash character such as in @"Go to C:\>Games\Prince".

Info: The expression condition ? trueCase : falseCase is a quick way of returning one value or another based on a condition (without using an if statement).

Info: At multiple places in the code, the programmer used if and for statements without writing curly braces to enclose the conditional or repeating code. In that case, only the statement immediately following will be executed as part of the if or for loop body.

In other words:
for (i = 0; i < 10; i++) streams.Add(random.Next(0, 80));

is equivalent to:
for (i = 0; i < 10; i++) 
{
    streams.Add(random.Next(0, 80));
}

(Info continues on next page)

And:
for (i = 0; i < 10; i++)
    streams.Add(random.Next(0, 80)); 
    Console.WriteLine(i);

is equivalent to:
for (i = 0; i < 10; i++) 
{
    streams.Add(random.Next(0, 80));
}

Console.WriteLine(i);

and not:
for (i = 0; i < 10; i++) 
{
    streams.Add(random.Next(0, 80));
    Console.WriteLine(i);
}

Be careful if you're using such statements without the curly braces as it easily leads to errors. For this reason, it is recommended that you always use curly braces, even if you just need to execute one line of code inside the if or while/for.
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w03d02m04 {
    class Program {
        static void Main(string[] args) {
            TheMatrix();
        }

        static void TheMatrix() {
            var random = new Random();
            var streams = new List<int> { };
            var symbols = @"!@#$%^&*()_+-=[];',.\/~{}:|<>?";

            for (int i = 0; i < 10; i++) {
                streams.Add(random.Next(0, Console.BufferWidth-1));
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            while (true) {
                for (int x = 0; x < Console.BufferWidth-1; x++) {
                    Console.Write(streams.Contains(x) ? symbols[random.Next(symbols.Length)] : ' ');
                }

                Console.WriteLine();
                System.Threading.Thread.Sleep(30);


                if (random.Next(3) == 0 && streams.Count > 0) {
                    streams.RemoveAt(random.Next(streams.Count));
                }
                if (random.Next(3) == 0) {
                    streams.Add(random.Next(0, Console.BufferWidth-1));
                }
            }
        }
    }
}