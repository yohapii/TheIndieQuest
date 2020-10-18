using System;

namespace w05d01m03 {
    class Program {
        static Random rand = new Random();

        static void Main(string[] args) {
            DrawMap(75, 30, "CITY MAP"); // (width, height, "title") - Mimimum width is 15.
        }

        static void DrawMap(int width, int height, string title) {

            // Prepare from this point
            //

            var roads = new bool[width, height];
            for (int i = 0; i < 6; i++) {
                GenerateIntersection(roads, rand.Next(width), rand.Next(height));
            }

            // Draw from this point
            //

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {

                    //border
                    if (IsBorder(x, y, width, height)) {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

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

                    //title
                    if (y == 1 && x == width / 2 - title.Length / 2) {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(title);
                        x += title.Length - 1;
                        continue;
                    }

                    //roads
                    bool neighborUpIsRoad = roads[x, y - 1];
                    bool neighborDownIsRoad = roads[x, y + 1];
                    bool neighborLeftIsRoad = roads[x - 1, y];
                    bool neighborRightIsRoad = roads[x + 1, y];

                    if (roads[x, y]) {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (neighborUpIsRoad && neighborDownIsRoad && neighborLeftIsRoad && neighborRightIsRoad) {
                            Console.Write("╬");
                        }
                        else if (neighborUpIsRoad && neighborDownIsRoad && neighborLeftIsRoad) {
                            Console.Write("╣");
                        }
                        else if (neighborUpIsRoad && neighborDownIsRoad && neighborRightIsRoad) {
                            Console.Write("╠");
                        }
                        else if (neighborUpIsRoad && neighborLeftIsRoad && neighborRightIsRoad) {
                            Console.Write("╩");
                        }
                        else if (neighborDownIsRoad && neighborLeftIsRoad && neighborRightIsRoad) {
                            Console.Write("╦");
                        }
                        else if (neighborUpIsRoad && neighborLeftIsRoad) {
                            Console.Write("╝");
                        }
                        else if (neighborDownIsRoad && neighborLeftIsRoad) {
                            Console.Write("╗");
                        }
                        else if (neighborUpIsRoad && neighborRightIsRoad) {
                            Console.Write("╚");
                        }
                        else if (neighborDownIsRoad && neighborRightIsRoad) {
                            Console.Write("╔");
                        }
                        else if (neighborUpIsRoad || neighborDownIsRoad) {
                            Console.Write("║");
                        }
                        else if (neighborLeftIsRoad || neighborRightIsRoad) {
                            Console.Write("═");
                        }
                        continue;
                    }

                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }


        static void GenerateIntersection(bool[,] roads, int x, int y) {
            for (int i = 0; i < 4; i++) {
                if (rand.Next(10) < 7) {
                    GenerateRoad(roads, x, y, i);
                }
            }
        }

        static void GenerateRoad(bool[,] roads, int startX, int startY, int direction) {
            int width = roads.GetLength(0);
            int height = roads.GetLength(1);

            //right
            if (direction == 0) {
                for (int i = startX; i < width; i++) {
                    roads[i, startY] = true;
                }
            }

            //down
            if (direction == 1) {
                for (int i = startY; i < height; i++) {
                    roads[startX, i] = true;
                }
            }

            //left
            if (direction == 2) {
                for (int i = startX; i > 0; i--) {
                    roads[i, startY] = true;
                }
            }

            //up
            if (direction == 3) {
                for (int i = startY; i > 0; i--) {
                    roads[startX, i] = true;
                }
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