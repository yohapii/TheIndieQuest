using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w03d03m01 {
    class Program {
        static Random rand = new Random();

        static void Main(string[] args) {
            DrawMap(140, 40);
        }

        static int RandomPath(int previousCoordinate, int changeChance, int maxNumber) {
            bool isPlus = Convert.ToBoolean(rand.Next(0, 2));
            bool isExecute = false;

            if (rand.Next(0, changeChance) == 0) {
                isExecute = true;
            }

            if (isExecute) {
                if (isPlus) {
                    if (maxNumber - 2 == previousCoordinate) {
                        return previousCoordinate;
                    }
                    return previousCoordinate + 1;
                }
                else {
                    return previousCoordinate - 1;
                }
            }
            else {
                return previousCoordinate;
            }

        }

        static bool IsBridge(int index, int roadCoordinates) {
            if (index >= roadCoordinates && index <= roadCoordinates + 6) {
                return true;
            }
            else {
                return false;
            }
        }

        static void DrawMap(int width, int height) {
            // Prepare from this point
            var riverCoordinates = new List<int>();
            for (int i = 0; i < height; i++) {
                if (i == 0) {
                    riverCoordinates.Add(rand.Next(Convert.ToInt32(width * 0.75), width - 2));
                }
                else {
                    riverCoordinates.Add(RandomPath(riverCoordinates[i - 1], 2, width));
                }
            }
            int bridgeCoordinateY = rand.Next(height / 2 - height / 2 / 2, height / 2 - height / 2 / 2 + height / 2 + 1);
            int bridgeCoordinateX = riverCoordinates[bridgeCoordinateY];

            var horizontalRoadCoordinatesY = new List<int>();

            horizontalRoadCoordinatesY.Add(bridgeCoordinateY + 1);

            //growing road from left of bridge to left edge
            int j = 0;
           for (int i = bridgeCoordinateX - 1; i > 0; i--) {
                horizontalRoadCoordinatesY.Add(RandomPath(horizontalRoadCoordinatesY[j], 7, height));
                j++;
            }

            horizontalRoadCoordinatesY.Reverse();

            //growing road from right of bridge to right edge
            for (int i = horizontalRoadCoordinatesY.Count() - 1; i < width; i++) {
                if (IsBridge(i, bridgeCoordinateX - 1)) {
                    horizontalRoadCoordinatesY.Add(horizontalRoadCoordinatesY[i]);
                }
                else {
                    horizontalRoadCoordinatesY.Add(RandomPath(horizontalRoadCoordinatesY[i], 3, height));
                }
            }

            // Draw from this point
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

                    if (x < width / 4 && IsRoad(horizontalRoadCoordinatesY[x], y) == false) {
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

                    //bridge
                    if (IsBridge(x, bridgeCoordinateX - 1) && IsRoad(horizontalRoadCoordinatesY[x], y + 1) || IsBridge(x, bridgeCoordinateX - 1) && IsRoad(horizontalRoadCoordinatesY[x], y - 1)) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("B");

                        continue;
                    }

                    //road
                    if (IsRoad(horizontalRoadCoordinatesY[x], y)) {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("#");
                    }
                    else {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        static bool IsRoad(int x, int y) {
            if (x == y) {
                return true;
            }
            else {
                return false;
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
