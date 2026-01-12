using System;
using System.Collections.Generic;
using System.Text;

namespace GIK299_L4_Labbgrupp27
{
    public enum Gender // we make Man = 1 so it matches the user input
    {
        Man = 1,
        Woman,
        NonBinary,
        Other
    }

    public class GenderCreation
    {
        public static void CreateGender()
        {
            Console.WriteLine("Please select one of the following genders");
            int current = 1;
            foreach (Gender g in Enum.GetValues(typeof(Gender))) // Loops through all enum values and we can add more genders without changing this code
            {
                Console.WriteLine($"{current}. " + g);
                current++;
            }
            Console.Write("Select (1-4): ");


            while (true)
            {
                string input = Console.ReadLine();

                // Check if a valid number was entered
                if (Enum.TryParse(input, out Gender chosenGender) && Enum.IsDefined(typeof(Gender), chosenGender))
                {
                    Console.WriteLine($"You selected: {chosenGender}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
        }
    }
}
