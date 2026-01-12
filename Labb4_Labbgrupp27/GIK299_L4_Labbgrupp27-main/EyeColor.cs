using System;
using System.Collections.Generic;
using System.Text;

namespace GIK299_L4_Labbgrupp27
{
    public enum Eyecolor // we make brown = 1 so it matches the user input
    {
        Brown = 1,
        Blue,
        Green,
        Gray,
        Hazel,
    }
    public class EyeCreation
    {
        public static Eyecolor CreateEye()
        {
            Console.WriteLine("Please select one of the following eyecolors");

            int current = 1;
            foreach (Eyecolor c in Enum.GetValues(typeof(Eyecolor))) // Loops through all enum values and we can add more eyecolors without changing this code
            {
                Console.WriteLine($"{current}. " + c);
                current++;
            }


            while (true)
            {

                Console.Write("Select (1-6): ");
                string input = Console.ReadLine();
                // Check if a valid number was entered
                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 6)
                {
                    Eyecolor selected = (Eyecolor)choice;
                    Console.WriteLine($"You selected: {selected}");
                    return selected;
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }


            }

        }
    }
}
