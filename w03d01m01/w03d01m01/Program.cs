using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w03d01m01 {
    class Program {
        static Random rand = new Random();

        static void Main(string[] args) {
            BowlingGame();
        }

        static void BowlingGame() {
            int totalFrames = 10;

            int firstThrow = 0;
            int secondThrow = 0;

            for (int currentFrame = 0; currentFrame < totalFrames; currentFrame++) {
                var standingPinsList = new List<bool> { true, true, true, true, true, true, true, true, true, true };

                for (int i = 0; i < 3; i++) {
                    Console.WriteLine($"FRAME {currentFrame + 1}");
                    if (i == 0) {
                        DrawFrame();
                        DrawPins(standingPinsList);
                    }
                    else if (i == 1) {
                        firstThrow = rand.Next(0, 11);
                        DrawFrame(firstThrow);

                        // Generating the base pattern of standing pins based on firstThrow.
                        standingPinsList.Clear();
                        for (int j = 0; j < 10; j++) {
                            if (firstThrow < j + 1) {
                                standingPinsList.Add(true);
                            }
                            else {
                                standingPinsList.Add(false);
                            }
                        }
                        // A cool snippet i found on the World Wide Web, for shuffling the contents of a list.
                        standingPinsList = standingPinsList.OrderBy(x => Guid.NewGuid()).ToList();

                        DrawPins(standingPinsList);
                    }
                    else if (i == 2) {
                        secondThrow = rand.Next(0, 11 - firstThrow);
                        DrawFrame(firstThrow, secondThrow);

                        // Code might be a bit inefficient, but it stubbornly searches for pins to knock down based on secondThrow.
                        int isThisKnocked;
                        int knockedPins = 0;
                        while (knockedPins < secondThrow) {
                            isThisKnocked = rand.Next(0, 10);
                            if (standingPinsList[isThisKnocked]) {
                                standingPinsList[isThisKnocked] = false;
                                knockedPins++;
                            }
                            if (! standingPinsList.Contains(true)) {
                                break;
                            }
                        }

                        DrawPins(standingPinsList);
                    }

                    Console.WriteLine();

                    if (i + 1 < 3 && firstThrow != 10) {
                        Console.WriteLine("Press Enter to throw.");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) {
                        }
                        Console.Clear();
                    }
                    else {
                        Console.WriteLine("Press Enter to continue.");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) {
                        }
                        Console.Clear();
                    }

                    if (firstThrow == 10) {
                        i = 3;
                        firstThrow = 0;
                    }
                }
            }
        }

        static void DrawFrame(int firstRoll = -1, int secondRoll = -1) {
            string first = " ";
            string second = " ";

            Console.Write("+-----");
            Console.Write("+");
            Console.WriteLine();

            if (firstRoll != 10) {
                if (firstRoll == 0) {
                    first = "-";
                }
                else if (firstRoll == -1) {
                    first = " ";
                }
                else {
                    first = firstRoll.ToString();
                }

                if (secondRoll == 0) {
                    second = "-";
                }
                else if (secondRoll + firstRoll == 10) {
                    second = "/";
                }
                else if (secondRoll == -1) {
                    second = " ";
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
            Console.Write("|");
            Console.WriteLine();
            Console.Write("+ ----");
            Console.Write("+");
            Console.WriteLine();
            Console.Write("+     ");
            Console.Write("+");
            Console.WriteLine();
            Console.Write("+-----");
            Console.Write("+");
            Console.WriteLine();
            Console.WriteLine();
        }

        static void DrawPins(List<bool> standingPinsList) {
            Console.WriteLine("Current pins:");
            Console.WriteLine();

            // back row
            DrawRow(7, 10, standingPinsList);

            // middleback row
            DrawRow(4, 6, standingPinsList, " ");

            // middlefront row
            DrawRow(2, 3, standingPinsList, "  ");

            // front pin
            DrawRow(1, 1, standingPinsList, "   ");
        }

        static void DrawRow(int startpin, int lastpin, List<bool> standingPinsList, string padding = "") {
            Console.Write(padding);
            for (int i = startpin - 1; i < lastpin; i++) {
                if (standingPinsList[i]) {
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
