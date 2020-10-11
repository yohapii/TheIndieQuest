using System;

namespace w03d04m02 {
    class Program {
        static void Main(string[] args) {
            FactorialList(10);
        }

        static void FactorialList(int amount = 0) {
            for (int i = 0; i <= amount; i++) {
                Console.WriteLine($"{i}! = {Factorial(i)}");
            }
        }

        static int Factorial(int n = 0) {
            if (n == 0) {
                return 1;
            }
            else {
                return n * Factorial(n - 1);
            }
        }
    }
}