using System;
using System.Collections.Generic;
using System.Text;

namespace GIK299_L4_Labbgrupp27
{
    public class Person
    {
        public static List<Person> ListPersons = new List<Person> { }; // Static list to hold all created persons

        public Hair hairColor { get; set; }
        public Gender sex { get; set; }
        public Eyecolor eyeClr { get; set; }
        public string dateOfBirth { get; set; }

        public Person(Hair haircolinput, Gender gender, Eyecolor eyecolor, int day, int month, int year) // Constructor for creating new person
        {
            hairColor = haircolinput;
            sex = gender;
            eyeClr = eyecolor;
            dateOfBirth = DoB.FormatDateOfBirth(day, month, year);
        }

        public override string ToString() // Override ToString to display person's information
        {
            return $"{hairColor} " + $"\nGender: {sex + 1}" + $"\nEyecolor: {eyeClr}" + $"\nDate of Birth (DD-MM-YY): {dateOfBirth}";
        }

        public static void AddPerson(Person newPerson)
        {
            ListPersons.Add(newPerson);
        }
            
    }
}