using System;

namespace w05d03m03 {
    class Program {
        static void Main(string[] args) {
            string username;

            username = "batman";
            PrintResult(CheckUsername(username), username);
            // true

            username = "player1";
            PrintResult(CheckUsername(username), username);
            // true

            username = "1234";
            PrintResult(CheckUsername(username), username);
            // true

            username = "deathEATER";
            PrintResult(CheckUsername(username), username);
            // false

            username = "warrior-princess";
            PrintResult(CheckUsername(username), username);
            // false

            Console.WriteLine();
        }

        static bool CheckUsername(string username) {
            for (int i = 0; i < username.Length; i++) {
                if (!Char.IsDigit(username[i]) && !Char.IsLower(username[i])) {
                    return false;
                }
            }

            return true;
        }

        static void PrintResult(bool result, string username) {
            Console.Write($"{username} = ");

            if (result) {
                Console.WriteLine("True");
            }
            else {
                Console.WriteLine("False");
            }
        }
    }
}
