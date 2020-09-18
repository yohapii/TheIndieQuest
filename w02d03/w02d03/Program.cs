using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w02d03
{
    class Program
    {
        static void Main(string[] args)
        {
            var Random = new Random();
            for (int i = 0; i < 1; i++)
            {
                WarriorHP(Random.Next());
                RollToSix(Random.Next());
                CharacterAndCubes(Random.Next());
                BowlingScore(Random.Next());

            }
            Console.Read();
        }

        static void BowlingScore(int RandSeed)
        {
            var random = new Random(RandSeed);
            int firstRoll = 0;
            int secondRoll = 0;

            string first = " ";
            string second = " ";

            int frames = 0;
            int totalFrames = 10;

            while (frames < totalFrames)
            {
                Console.Write("+-----");
                frames++;
            }
            Console.Write("+");
            Console.WriteLine();
            frames = 0;
            while (frames < totalFrames)
            {
                random = new Random(RandSeed+(frames*1337));
                firstRoll = random.Next(0, 11);
                if (firstRoll != 10)
                {
                    if (firstRoll == 0)
                    {
                        //Console.WriteLine($"First roll: -");
                        first = "-";
                    }
                    else
                    {
                        //Console.WriteLine($"First roll: {firstRoll}");
                        first = firstRoll.ToString();
                    }

                    secondRoll = random.Next(0, 11 - firstRoll);
                    if (secondRoll == 0)
                    {
                        //Console.WriteLine($"Second roll: -");
                        second = "-";
                    }
                    else if (secondRoll + firstRoll == 10)
                    {
                        //Console.WriteLine($"Second roll: /");
                        second = "/";
                    }
                    else
                    {
                        //Console.WriteLine($"Second roll: {secondRoll}");
                        second = secondRoll.ToString();
                    }
                }
                else
                {
                    //Console.WriteLine($"First roll: X");
                    first = "X";
                    second = " ";
                }
                //Console.WriteLine();
                //Console.WriteLine();
                //Console.WriteLine($"{secondRoll + firstRoll} knocked pins:");
                Console.Write("| ");
                Console.Write($"|{first}");
                Console.Write($"|{second}");
                frames++;
            }
            Console.Write("|");
            Console.WriteLine();
            frames = 0;
            while (frames < totalFrames)
            {
                Console.Write("+ ----");
                frames++;
            }
            Console.Write("+");
            Console.WriteLine();
            frames = 0;
            while (frames < totalFrames)
            {
                Console.Write("+     ");
                frames++;
            }
            Console.Write("+");
            Console.WriteLine();
            frames = 0;
            while (frames < totalFrames)
            {
                Console.Write("+-----");
                frames++;
            }
            Console.Write("+");
            Console.WriteLine();
            End();
        }
        static void CharacterAndCubes(int RandSeed)
        {
            var random = new Random(RandSeed);
            int CharacterStrength = 0;
            int CubeHP = 0;
            int CubeArmyHP = 0;
            int CubeArmySize = 100;
            int DiceThrow;
            for (int i = 0; i < 3; i++)
            {
                DiceThrow = random.Next(1, 7);
                //Console.WriteLine($"Dice no. {i + 1} result: {DiceThrow}");
                CharacterStrength = CharacterStrength + DiceThrow;
            }
            Console.WriteLine($"A character with the strength of {CharacterStrength} was created.");

            for (int i = 0; i < 8; i++)
            {
                DiceThrow = random.Next(1, 11);
                //Console.WriteLine($"Dice no. {i + 1} result: {DiceThrow}");
                CubeHP = CubeHP + DiceThrow;
            }
            //Console.WriteLine($"Dice sum: {CubeHP}");
            CubeHP = CubeHP + 40;
            //Console.WriteLine($"Added 40:");
            Console.WriteLine($"A gelatinous cube with {CubeHP} HP appears!");
            
            for (int i = 0; i < CubeArmySize; i++)
            {
                for (int ii = 0; ii < 8; ii++)
                {
                    DiceThrow = random.Next(1, 11);
                    //Console.WriteLine($"Dice no. {ii + 1} result: {DiceThrow}");
                    CubeArmyHP = CubeArmyHP + DiceThrow;
                }
                //Console.WriteLine($"Cube Army HP + new dices result: {CubeArmyHP}");
                CubeArmyHP = CubeArmyHP + 40;
                //Console.WriteLine($"Added 40:");
                //Console.WriteLine($"Cube Army total HP: {CubeArmyHP}, consisting of: {i+1} cubes");
            }
            Console.WriteLine($"Dear gods, an army of {CubeArmySize} cubes descends upon us with a total of {CubeArmyHP} HP. We are doomed!");
            End();
        }
        static void RollToSix(int RandSeed)
        {
            var random = new Random(RandSeed);
            int DiceThrow = random.Next(1, 7);
            Console.WriteLine($"The player rolls: {DiceThrow}");
            int Score = DiceThrow;
            while (DiceThrow != 6)
            {
                DiceThrow = random.Next(1, 7);
                Console.WriteLine($"The player rolls: {DiceThrow}");
                Score = Score + DiceThrow;
            }
            Console.WriteLine($"Total score: {Score}");
            End();

        }
        
        static void WarriorHP(int RandSeed)
        {            
            var Random = new Random(RandSeed);
            int WarriorHP = Random.Next(1, 101);
            Console.WriteLine($"Warrior HP: {WarriorHP}");
            Regenerate(WarriorHP);
            End();
        }
        static void Regenerate(int x)
        {
            Console.WriteLine("Regenerate spell is cast!");
            while (x < 50)
            {
                x = x + 10;
                Console.WriteLine($"Warrior HP: {x}");
            }
            Console.WriteLine("Regenerate spell is complete!");
        }
        static void End()
        {
            Console.WriteLine("--END OF PROGRAM");
            Console.WriteLine("");
        }
    }
}
