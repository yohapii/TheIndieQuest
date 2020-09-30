using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w04d02m01 {
    class Program {
        static Random rand = new Random();

        static void Main(string[] args) {
            DrawMap(75, 20, "ADVENTURE MAP"); // (width, height, "title") - Mimimum width is 15.
        }

        static void DrawMap(int width, int height, string title) {

            // Prepare from this point
            //
            var riverCoordinates = new List<int>();
            for (int i = 0; i < height; i++) {
                if (i == 0) {
                    riverCoordinates.Add(rand.Next(width / 4 * 3, width / 15 * 14));
                }
                else {
                    riverCoordinates.Add(RandomPath(riverCoordinates[i - 1], 2, width));
                }
            }
            int bridgeCoordinateY = rand.Next(height / 2 / 2, height / 4 * 3);
            int bridgeCoordinateX = riverCoordinates[bridgeCoordinateY];

            var horizontalRoadCoordinatesY = new List<int>();

            horizontalRoadCoordinatesY.Add(bridgeCoordinateY + 1);

            //growing road from left of bridge to left edge
            int j = 0;
            for (int i = bridgeCoordinateX - 1; i > 0; i--) {
                horizontalRoadCoordinatesY.Add(RandomPath(horizontalRoadCoordinatesY[j], 7, height));
                j++;
            }

            //reversing list because it was made in reverse up to this point
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
            //
            bool bridgeDrawn = false;

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
                        x += title.Length-1;
                        continue;
                    }

                    //trees
                    if (x < width / 4 && IsRoad(horizontalRoadCoordinatesY[x], y) == false) {
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
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("=");
                        bridgeDrawn = true;
                        continue;
                    }

                    //horizontal road
                    if (IsRoad(horizontalRoadCoordinatesY[x], y)) {
                        DrawRoad();
                        continue;
                    }

                    //vertical road next to river
                    if (bridgeDrawn && IsRiverEdge(x, riverCoordinates[y])) {
                        DrawRoad();
                        continue;
                    }

                    //river
                    if (IsRiver(x, riverCoordinates[y])) {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(RiverDirection(riverCoordinates[y], riverCoordinates[y + 1]));
                        continue;
                    }

                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        static void DrawRoad() {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("#");
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

        static bool IsRiver(int index, int riverCoordinate) {
            if (index > riverCoordinate && index <= riverCoordinate + 3) {
                return true;
            }
            else {
                return false;
            }
        }

        static bool IsRiverEdge(int index, int riverCoordinate) {
            if (index + 4 == riverCoordinate) {
                return true;
            }
            else {
                return false;
            }
        }

        static string RiverDirection(int riverCoordinate, int nextRiverCoordinate) {
            if (riverCoordinate == nextRiverCoordinate) {
                return "|";
            }
            else if (riverCoordinate < nextRiverCoordinate) {
                return @"\";
            }
            else {
                return "/";
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
