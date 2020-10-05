using System;

namespace w02d04m02 {
    class Program {
        static Random dice = new Random();
        static void Main(string[] args) {
            TankGame();
        }

        static void TankGame() {
            string artilleryGraphic = "_/";
            string tankGraphic = "T";
            string explosionGraphic = "B   (oom)";
            int playingField = 80;
            int distanceToTank = dice.Next(40, 71);
            bool gameIsOn = true;
            bool gameIsWin = false;

            Console.WriteLine($"DANGER! A tank is approaching our position. Your artillery unit is our only hope!");
            Console.WriteLine();
            Console.WriteLine("What is your name, commander?");
            Console.Write("Enter name: ");

            string name = Console.ReadLine();

            while (gameIsOn && distanceToTank > 0) {
                Console.Clear();
                DrawBattlefield(artilleryGraphic, tankGraphic, distanceToTank, playingField);

                Console.WriteLine();
                Console.WriteLine($"Aim your shot, {name}!");
                Console.Write("Enter distance: ");

                string numberText = Console.ReadLine();
                int aimedDistance = Int32.Parse(numberText) - 1;

                for (int i = 0; i < artilleryGraphic.Length + aimedDistance; i++) {
                    Console.Write(" ");
                }

                Console.WriteLine(explosionGraphic);

                if (aimedDistance == distanceToTank) {
                    Console.WriteLine($"You hit the tank! Good job, {name}!");

                    gameIsOn = false;
                    gameIsWin = true;
                }
                else if (aimedDistance > distanceToTank) {
                    Console.WriteLine("No... You aimed too far.");

                    distanceToTank -= dice.Next(1, 16);

                    Console.WriteLine();
                    Console.WriteLine("Press Enter to see the new battlefield.");
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                }
                else {
                    Console.WriteLine("Oops, that aim was too short.");

                    distanceToTank -= dice.Next(1, 16);

                    Console.WriteLine();
                    Console.WriteLine("Press Enter to see the new battlefield.");
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                }
            }

            if (gameIsWin) {
                Console.WriteLine();
                Console.WriteLine("YOU WIN!");
            }
            else {
                Console.Clear();
                DrawBattlefield(artilleryGraphic, tankGraphic, distanceToTank, playingField);

                Console.WriteLine();
                Console.WriteLine("The tank is here now, that means:");
                Console.WriteLine("GAME OVER, NOOB.");
            }

            Console.WriteLine();
        }

        static void DrawBattlefield(string artilleryGraphic, string tankGraphic, int distanceToTank, int playingField) {
            Console.WriteLine($"Here is the map of the battlefield:");
            Console.WriteLine();
            Console.Write($"{artilleryGraphic}");

            for (int i = 0; i < distanceToTank; i++) {
                Console.Write("_");
            }

            Console.Write($"{tankGraphic}");

            for (int i = 0; i < playingField - distanceToTank - artilleryGraphic.Length - 1; i++) {
                Console.Write("_");
            }

            Console.WriteLine();
        }
    }
}
