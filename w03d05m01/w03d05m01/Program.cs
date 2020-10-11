using System;
using System.Collections.Generic;

namespace w03d05m01 {
    class Program {
        static Random rand = new Random();

        static void Main(string[] args) {
            BowlingGame();
        }

        static void BowlingGame() {
            int totalFrames = 10;

            int path = 0;
            int firstThrow = 0;
            int secondThrow = 0;

            for (int currentFrame = 0; currentFrame < totalFrames; currentFrame++) {
                var pinsStanding = new List<bool> { true, true, true, true, true, true, true, true, true, true };
                int lucky = 1;

                for (int i = 0; i < 3; i++) {
                    Console.WriteLine($"FRAME {currentFrame + 1}");
                    if (i == 0) {
                        DrawFrame();
                        DrawPins(pinsStanding);
                    }
                    else if (i == 1) {
                        firstThrow = KnockPinOnPath(path, pinsStanding, lucky);
                        DrawFrame(firstThrow);
                        DrawPins(pinsStanding);
                    }
                    else if (i == 2) {
                        secondThrow = KnockPinOnPath(path, pinsStanding, lucky);
                        DrawFrame(firstThrow, secondThrow);
                        DrawPins(pinsStanding);
                    }

                    if (i + 1 < 3 && firstThrow != 10) {
                        lucky = SetLuck();

                        Console.WriteLine("1 2 3 4 5 6 7\n");
                        Console.Write($"Feeling: ");
                        if (lucky == 2) {
                            Console.WriteLine("Lucky!!");
                        }
                        else if (lucky == 1) {
                            Console.WriteLine("OK.");
                        }
                        else {
                            Console.WriteLine("a bit nervous...");
                        }
                        Console.Write("Enter where to aim and throw the ball (1-7): ");

                        while (!int.TryParse(Console.ReadLine(), out path)) {
                            Console.Write("Enter a valid number: ");
                        }
                        if (lucky == 0) {
                            int oldPath = path;
                            path += rand.Next(-1, 2);
                            if (oldPath != path) {
                                Console.WriteLine($"Oof! Aim accidentally changed to {path}!");
                                Console.Write("Press Enter to continue. ");
                                while (Console.ReadKey().Key != ConsoleKey.Enter) {
                                }
                            }
                        }

                        Console.Clear();
                    }
                    else {
                        Console.WriteLine("1 2 3 4 5 6 7\n");
                        Console.WriteLine("Press Enter to continue. ");

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

        static void DrawFrame(int firstThrow = -1, int secondThrow = -1) {
            string firstThrowText = " ";
            string secondThrowText = " ";

            Console.Write("+-----");
            Console.Write("+\n");

            if (firstThrow != 10) {
                if (firstThrow == 0) {
                    firstThrowText = "-";
                }
                else if (firstThrow == -1) {
                    firstThrowText = " ";
                }
                else {
                    firstThrowText = firstThrow.ToString();
                }

                if (secondThrow == 0) {
                    secondThrowText = "-";
                }
                else if (secondThrow + firstThrow == 10) {
                    secondThrowText = "/";
                }
                else if (secondThrow == -1) {
                    secondThrowText = " ";
                }
                else {
                    secondThrowText = secondThrow.ToString();
                }
            }
            else {
                firstThrowText = "X";
                secondThrowText = " ";
            }

            Console.Write("| ");
            Console.Write($"|{firstThrowText}");
            Console.Write($"|{secondThrowText}");
            Console.Write("|\n");
            Console.Write("+ ----");
            Console.Write("+\n");
            Console.Write("+     ");
            Console.Write("+\n");
            Console.Write("+-----");
            Console.Write("+\n\n");
        }

        static void DrawPins(List<bool> pinsStanding) {
            Console.WriteLine("Current pins:\n");

            // back row
            DrawRow(7, 10, pinsStanding);

            // middleback row
            DrawRow(4, 6, pinsStanding, "  ");

            // middlefront row
            DrawRow(2, 3, pinsStanding, "    ");

            // front pin
            DrawRow(1, 1, pinsStanding, "      ");
        }

        static void DrawRow(int startpin, int lastpin, List<bool> pinsStanding, string padding = "") {
            Console.Write(padding);
            for (int i = startpin - 1; i < lastpin; i++) {
                if (pinsStanding[i]) {
                    Console.Write("O   ");
                }
                else {
                    Console.Write("    ");
                }
            }
            Console.WriteLine("\n");
        }

        static int KnockPinOnPath(int path, List<bool> pinsStanding, int lucky = 1) {
            int knockedPinsCount = 0;
            if (path == 1) {
                if (pinsStanding[7 - 1]) {
                    pinsStanding[7 - 1] = false;
                    knockedPinsCount++;
                }
            }
            else if (path == 2) {
                if (pinsStanding[4 - 1]) {
                    pinsStanding[4 - 1] = false;
                    knockedPinsCount++;
                }
            }
            else if (path == 3) {
                if (pinsStanding[2 - 1] == false) {
                    if (pinsStanding[8 - 1]) {
                        pinsStanding[8 - 1] = false;
                        knockedPinsCount++;
                    }
                }
                else if (pinsStanding[2 - 1]) {
                    pinsStanding[2 - 1] = false;
                    knockedPinsCount++;
                }
            }
            else if (path == 4) {
                if (pinsStanding[1 - 1] == false) {
                    if (pinsStanding[5 - 1]) {
                        pinsStanding[5 - 1] = false;
                        knockedPinsCount++;
                    }
                }
                else if (pinsStanding[1 - 1]) {
                    pinsStanding[1 - 1] = false;
                    knockedPinsCount++;
                }
            }
            else if (path == 5) {
                if (pinsStanding[3 - 1] == false) {
                    if (pinsStanding[9 - 1]) {
                        pinsStanding[9 - 1] = false;
                        knockedPinsCount++;
                    }
                }
                else if (pinsStanding[3 - 1]) {
                    pinsStanding[3 - 1] = false;
                    knockedPinsCount++;
                }
            }
            else if (path == 6) {
                if (pinsStanding[6 - 1]) {
                    pinsStanding[6 - 1] = false;
                    knockedPinsCount++;
                }
            }
            else if (path == 7) {
                if (pinsStanding[10 - 1]) {
                    pinsStanding[10 - 1] = false;
                    knockedPinsCount++;
                }
            }
            if (knockedPinsCount == 1) {
                for (int i = 0; i < (lucky == 2 ? 6 : 2); i++) {
                    path += rand.Next(-1, 2);
                    knockedPinsCount += KnockPinOnPath(path, pinsStanding, lucky);
                }
            }
            return knockedPinsCount;
        }

        static int SetLuck() {
            int dice = rand.Next(1, 7);
            if (dice == 6) {
                return 2;
            }
            else if (dice == 1) {
                return 0;
            }
            else {
                return 1;
            }
        }
    }
}
