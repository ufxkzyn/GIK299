using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using GIK299_L4_Labbgrupp27;

namespace GIK299_L4_Labbgrupp27
{
    public struct Hair
    {
        public string HairColor { get; set; }
        public int HairLength { get; set; }

        public Hair(string color, int length)
        {

            HairColor = color;
            HairLength = length;

        }

        public override string ToString()
        {
            return $"Hair Color: {HairColor} " + $"\nHair Length: {HairLength}cm";
        }
    }



    public static class HairCreation // we devided CreateHair into two parts to make it easier to read, Colour and Length.
    {
        public static string CreateHairColor()
        {

            string[] HairChoice = { "Black", "Brown", "Blonde", "Red", "White", "Multicolor" };

            Console.WriteLine("Please select one of the following Hair colors");
            int current = 1;
            foreach (string g in HairChoice)
            {
                Console.WriteLine($"{current}. " + g);
                current++;
            }
            Console.Write("Select (1-6): ");


            while (true)
            {
                string input = Console.ReadLine();
                int.TryParse(input, out int choice);

                // Check if input is of the correct type while also checking if it is within the allowed range
                if (choice == 1 || choice == 2 || choice == 3 || choice == 4 || choice == 5 || choice == 6)
                {
                    Console.WriteLine($"You selected: {HairChoice[choice-1]}");
                    return HairChoice[choice];
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
        }

        public static int CreateHairLength()
        {

            Console.WriteLine("Please write out ur hair length in cm: ");

            while (true)
            {
                string input = Console.ReadLine();
                // Check if input is of the correct type while also checking if it is within the allowed range
                if (int.TryParse(input, out int choice) && choice > 0 && choice < 300) // Sets a logical max range 
                {
                    Console.WriteLine($"You selected: {choice}cm");
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
        }
    }
}