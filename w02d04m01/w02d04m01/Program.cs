using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w02d04m01 {
    class Program {
        static void Main(string[] args) {
            var Random = new Random();
            for (int i = 0; i < 1; i++) {
                BowlingScore(Random.Next());

            }
        }

        static void BowlingScore(int RandSeed) {
            var random = new Random(RandSeed);
            int firstRoll = 0;
            int secondRoll = 0;

            string first = " ";
            string second = " ";

            int frames = 0;
            int totalFrames = 10;

            while (frames < totalFrames) {
                Console.Write("+-----");
                frames++;
            }
            Console.Write("+");
            Console.WriteLine();
            frames = 0;
            while (frames < totalFrames) {
                random = new Random(RandSeed + (frames * 1337));
                firstRoll = random.Next(0, 11);
                if (firstRoll != 10) {
                    if (firstRoll == 0) {
                        first = "-";
                    }
                    else {
                        first = firstRoll.ToString();
                    }

                    secondRoll = random.Next(0, 11 - firstRoll);
                    if (secondRoll == 0) {
                        second = "-";
                    }
                    else if (secondRoll + firstRoll == 10) {
                        second = "/";
                    }
                    else {
                        second = secondRoll.ToString();
                    }
                }
                else {
                    first = "X";
                    second = " ";
                }
                Console.Write("| ");
                Console.Write($"|{first}");
                Console.Write($"|{second}");
                frames++;
            }
            Console.Write("|");
            Console.WriteLine();
            frames = 0;
            while (frames < totalFrames) {
                Console.Write("+ ----");
                frames++;
            }
            Console.Write("+");
            Console.WriteLine();
            frames = 0;
            while (frames < totalFrames) {
                Console.Write("+     ");
                frames++;
            }
            Console.Write("+");
            Console.WriteLine();
            frames = 0;
            while (frames < totalFrames) {
                Console.Write("+-----");
                frames++;
            }
            Console.Write("+");
            Console.WriteLine();
            Console.WriteLine("--END OF PROGRAM");
            Console.WriteLine("");
        }
    }
}
