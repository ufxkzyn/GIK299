using System;
using System.Collections.Generic;
using System.Text;

namespace GIK299_L4_Labbgrupp27
{
    public class DoB
    {
        public static string FormatDateOfBirth(int day, int month, int year)
        {
            // Displays the year with two digits instead of four
            int twoDigitYear = year % 100;

            // Formats the date of birth before returning it
            return $"{day:D2}-{month:D2}-{twoDigitYear:D2}";
        }
        private static int CheckValidity(string prompt, int min, int max)
        {
            int result;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                // Check if input is of the correct type while also checking if it is within the allowed range
                if (int.TryParse(input, out result) && result >= min && result <= max)
                {
                    return result;
                }

                Console.WriteLine("Invalid input");
            }
        }

        public static void SelectDoB(out int d, out int m, out int y)
        {
            // Checks current year
            int currentYear = DateTime.Now.Year;

            y = CheckValidity($"Enter birth year (YYYY) (1900-{currentYear}): ", 1900, currentYear);
            m = CheckValidity("Enter birth month (MM): ", 1, 12);

            // Checks for change in amount of days due to month/leap year
            int maxDays = DateTime.DaysInMonth(y, m);

            d = CheckValidity($"Enter birth day (DD) (1-{maxDays}): ", 1, maxDays);


        }
    }
}