using System.Drawing;
using System;
using System.Collections;

namespace GIK299_L4_Labbgrupp27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int day, month, year;

            while (true)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Create Person");
                Console.WriteLine("2. View list");
                Console.WriteLine("4. Exit");
                string input = Console.ReadLine();
                int.TryParse(input, out int choice);

                switch (choice)
                {

                    case 1:
                        Console.WriteLine("Creating Person...");
                        // initialize the properties of Person
                        GenderCreation.CreateGender();
                        EyeCreation.CreateEye();

                        string chosenColor = HairCreation.CreateHairColor();
                        int chosenLength = HairCreation.CreateHairLength();

                        Hair haircolor = new Hair(chosenColor, chosenLength); 
                        Gender gender = new Gender { };
                        Eyecolor eyecolor = EyeCreation.CreateEye();
                        DoB.SelectDoB(out day, out month, out year);

                        // takes those given properties and creates a new Person and adds it to the list
                        Person newPerson = new Person(haircolor, gender, eyecolor, day, month, year);
                        Person.AddPerson(newPerson);
                        Console.Clear();

                        break;

                    case 2:
                        Console.WriteLine("Viewing list...");
                        if (Person.ListPersons.Count == 0)
                        {
                            Console.WriteLine("Empty List");
                            break;

                        }
                        else
                        {
                            Console.WriteLine("----------");
                            int peopleCounter = 1;
                            foreach (Person p in Person.ListPersons)
                            {
                                Console.WriteLine($"Person {peopleCounter}:\n{p.ToString()}");
                                Console.WriteLine("----------");
                                peopleCounter++;
                            }
                            break;
                        }

                    case 4:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        return;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        continue;
                }

            }
        }
    }
}