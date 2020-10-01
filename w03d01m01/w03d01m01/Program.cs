using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w03d01m01 {
    class Program {
        static void Main(string[] args) {
            Pins();
            Pins(       // Following pin is standing?
                true,   // Pin 1
                false,  // Pin 2
                true,   // Pin 3
                false,  // Pin 4
                true,   // Pin 5
                false,  // Pin 6
                true,   // Pin 7
                false,  // Pin 8
                true,   // Pin 9
                false   // Pin 10
                );
        }

        static void Pins(bool pin1 = true, bool pin2 = true, bool pin3 = true, bool pin4 = true, bool pin5 = true, bool pin6 = true, bool pin7 = true, bool pin8 = true, bool pin9 = true, bool pin10 = true) {
            var pinsStanding = new List<bool> { pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, pin9, pin10 };

            Console.WriteLine("Current pins:");
            Console.WriteLine();

            // back row
            DrawRow(7, 10, pinsStanding);

            // middleback row
            DrawRow(4, 6, pinsStanding, " ");

            // middlefront row
            DrawRow(2, 3, pinsStanding, "  ");

            // front pin
            DrawRow(1, 1, pinsStanding, "   ");

            Console.WriteLine();
            Console.WriteLine("--");
            Console.WriteLine();
        }

        static void DrawRow(int startpin, int lastpin, List<bool> pinList, string padding = "") {
            Console.Write(padding);
            for (int i = startpin - 1; i < lastpin; i++) {
                if (pinList[i]) {
                    Console.Write("o ");
                }
                else {
                    Console.Write("  ");
                }
            }
            Console.WriteLine();
        }
    }
}
