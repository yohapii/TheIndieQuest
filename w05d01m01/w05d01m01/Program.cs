using System;

namespace w05d01m01 {
    class Program {

        static void Main(string[] args) {
            Console.WriteLine(CreateDayDescription(17, 1, 1988));
            Console.WriteLine(CreateDayDescription(21, 3, 548));
            Console.WriteLine(CreateDayDescription(3, 2, 2054));
        }
        static string CreateDayDescription(int day, int season, int year) {

            string[] seasons = { "Spring", "Summer", "Autumn", "Winter" };
            return $"{OrdinalNumber(day)} day of {seasons[season]} in the year {year}";

        }

        static string OrdinalNumber(int number) {
            int lastDigit = number % 10;
            int secondToLastDigit = 0;

            if (number >= 10) {
                secondToLastDigit = number / 10 % 10;
            }
            if (secondToLastDigit == 1) {
                return number + "th";
            }
            if (lastDigit == 1) {
                return number + "st";
            }
            if (lastDigit == 2) {
                return number + "nd";
            }
            if (lastDigit == 3) {
                return number + "rd";
            }
            if (number == 0) {
                return "Zero";
            }
            return number + "th";
        }

    }
}
