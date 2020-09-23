using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w03d02m01 {
    class Program {
        static Random rand = new Random();

        static void Main(string[] args) {
            DrawMap(60, 20);
        }

        static void DrawMap(int width, int height) {
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {

                    if (IsBorder(x, y, width, height)) {
                        //border

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        if ((x == 0 || x == width - 1) && (y == 0 || y == height - 1)) {
                            //corner
                            Console.Write("+");
                            continue;
                        }
                        if (x == 0 || x == width - 1) {
                            //vertical
                            Console.Write("|");
                            continue;
                        }
                        else {
                            //horizontal
                            Console.Write("-");
                            continue;
                        }
                    }

                    if (x < width / 4) {
                        //trees

                        string trees = @"%()TA@";

                        Console.ForegroundColor = ConsoleColor.Green;

                        if (rand.Next(0, x) <= 1) {
                            Console.Write(trees[rand.Next(trees.Length)]);
                        }
                        else {
                            Console.Write(" ");
                        }
                        continue;
                    }

                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }

        static bool IsBorder(int x, int y, int width, int height) {
            if (x == 0 || x == width - 1 || y == 0 || y == height - 1) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
