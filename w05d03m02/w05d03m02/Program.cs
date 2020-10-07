/*  Outputs an ASCII chart.
 */

using System;

namespace w05d03m02 {
    class Program {
        static void Main(string[] args) {
            for (int i = 0; i <= 255; i++) {
                if (i < 10) {
                    Console.Write("  ");
                }
                else if (i < 100) {
                    Console.Write(" ");
                }
                if (i == 10) {
                    Console.WriteLine($"{i} = (line break)");
                }
                else {
                    Console.WriteLine($"{i} = {(char)i}");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}