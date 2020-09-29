using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

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
            int shellAmount = 3;
            int distanceToTank = dice.Next(40, 71);
            bool gameIsOn = true;
            bool gameIsWin = false;

            Console.WriteLine($"DANGER! A tank is approaching our position. Your artillery unit is our only hope!");
            Console.WriteLine();
            Console.WriteLine("What is your name, commander?");
            Console.Write("Enter name: ");

            string name = Console.ReadLine();

            Console.WriteLine();
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

            while (gameIsOn && shellAmount > 0) {
                //Console.Write("Distance to tank: " + distanceToTank);

                Console.WriteLine();
                Console.WriteLine($"Aim your shot, {name}!");
                Console.Write("Enter distance: ");

                string numberText = Console.ReadLine();
                int aimedDistance = Int32.Parse(numberText);

                for (int i = 0; i < artilleryGraphic.Length + aimedDistance; i++) {
                    Console.Write(" ");
                }

                Console.WriteLine(explosionGraphic);

                //Console.Write("You entered: " + aimedDistance);

                if (aimedDistance == distanceToTank) {
                    Console.WriteLine($"You hit the tank! Good job, {name}!");
                    gameIsOn = false;
                    gameIsWin = true;
                }
                else if (aimedDistance > distanceToTank) {
                    Console.WriteLine("No... You aimed too far.");
                    shellAmount--;
                }
                else {
                    Console.WriteLine("Oops, that aim was too short.");
                    shellAmount--;
                }
            }
            if (gameIsWin) {
                Console.WriteLine();
                Console.WriteLine("YOU WIN!");
            }
            else {
                Console.WriteLine();
                Console.WriteLine("GAME OVER, NOOB.");
            }

            Console.WriteLine();
        }
    }
}
