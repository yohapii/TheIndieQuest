/* Objective: Fractal
The first coworker to come to your desk today is one of the graphics engine programmers:

The producer said to show you some cool algorithms? Here's one that draws the Mandelbrot fractal. I wrote it in pseudocode so it's useful to whoever wants to try it, no matter the programming language. Well, there's some .NET specific stuff in there, but yeah, you should be good if you do it with C#. Check it out!

FOR y FROM -10 to 10 DO
    FOR x FROM 1 to 80 DO
        SET REAL r TO 0
        SET REAL i TO 0
        SET INTEGER k TO -1

        WHILE r² + i² < 11 AND k < 112
            SET REAL t TO r
            SET r TO t² - i² - 2.3 + x / 24.5
            SET i TO 2 * t * i + y / 8.5
            INCREMENT k
        END WHILE

        SET INTEGER c TO k MOD 16
        SET Console.BackgroundColor TO (ConsoleColor)c
        SEND ' ' TO DISPLAY
    END FOR

    SEND NEW LINE TO DISPLAY
END FOR

Completion goals:
1. Read Page 2 of the Algorithms article: Pseudo-code. https://www.bbc.co.uk/bitesize/guides/z7kkw6f/revision/2
2. Implement the above program in C#.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w03d03m01 {
    class Program {
        static void Main(string[] args) {
            for (int y = -10; y <= 10; y++) {
                for (int x = 1; x <= 80; x++) {
                    double r = 0;
                    double i = 0;
                    int k = -1;
                    while (((r * r) + (i * i)) < 11 && k < 112) {
                        double t = r;
                        r = (t * t) - (i * i) - 2.3 + x / 24.5;
                        i = 2 * t * i + y / 8.5;
                        k++;
                    }
                    int c = k % 16;
                    Console.BackgroundColor = (ConsoleColor)c;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}