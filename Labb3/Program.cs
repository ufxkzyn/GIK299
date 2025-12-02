using System;
using System.Diagnostics.CodeAnalysis;

namespace Labb3
{
    internal class Program
    {
        private static double NextDouble(Random rnd, double min, double max) // https://stackoverflow.com/questions/22046831/random-numbers-with-decimals
        {
            //max = 33.2;
            //min = -24.1;

            return rnd.NextDouble() * (max - min) + min;
        }

        static double[] days = new double[31]; // deklarerar days arrayen med 31 index för maj månad

        private static void DagOchTemp()
        {
            Random rnd = new Random(); //double TempDag = NextDouble(rnd, -24.1, 33.2);
            for (int i = 0; i < 31; i++) // här genererar vi alla dagarnas temp, days.length kommer längden på arrayen å kör tills vi uppnått sista indexen, i++ får oss å hoppa upp ett snäpp per loop.
            {
                double TempDag = NextDouble(rnd, -24.1, 33.2); // temperaturerna är tagna från min å max nånsin recorded i maj
                days[i] = TempDag;
            }
        }

        public static void Main(string[] args)
        {
            DagOchTemp();
            int MenyVal = 1;
            double Value = 0;
            int day = 1;
            double[] Copydays = new double[31];

            while (MenyVal != 0)

            {
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("1. Lista alla temperaturer för maj månad");
                Console.WriteLine("2. Visa medeltempraturen för maj månad");
                Console.WriteLine("3. Visa den varmaste dagen i maj månad");
                Console.WriteLine("4. Visa den lägsta temperaturen som varit i maj månad");
                Console.WriteLine("5. Visa mediantemperaturen för maj månad");
                Console.WriteLine("6. Sortera temperaturerna för maj månad");
                Console.WriteLine("7. Visa bara dagar över/under ett visst värde för maj månad");
                Console.WriteLine("8. Vill du veta en specific dags temperatur?");
                Console.WriteLine("9. Visa den vanligast förekommande tempreaturen för maj månad");
                Console.WriteLine("0. Avsluta programmet");
                int.TryParse(Console.ReadLine(), out MenyVal);

                switch (MenyVal)
                {
                    case 1:
                        for (int i = 0; i < 31; i++)
                        {
                            Console.WriteLine("Dag " + (i + 1) + ": " + String.Format("{0:.00}", days[i]) + "°C");
                        }
                        break;

                    case 2:
                        double sum = days.Sum() / 31;
                        Console.WriteLine($"Medeltemperaturen för maj månad var: " + String.Format("{0:.00}", sum) + "°C");
                        Value = 0;
                        break;

                    case 3:
                        for (int i = 0; i < 31; i++)
                        {
                            if (days[i] > Value)
                            {
                                Value = days[i];
                                day = i + 1;
                            }
                        }
                        Console.WriteLine($"Den varmaste dagen för maj månad var: Dag " + (day) + ": " + String.Format("{0:.00}", Value) + "°C");
                        Value = 0;
                        break;

                    case 4:
                        for (int i = 0; i < 31; i++)
                        {
                            if (days[i] < Value) // jämför alla dagar och spar den kallaste dagen
                            {
                                Value = days[i];
                                day = i + 1;
                            }
                        }
                        Console.WriteLine($"Den kallaste dagen för maj månad var: Dag " + (day) + ": " + String.Format("{0:.00}", Value) + "°C");
                        Value = 0;
                        break;

                    case 5:
                        Array.Copy(days, Copydays, days.Length); // gör en kopia av våran array så vi inte rör runt i den riktiga
                        Array.Sort(Copydays);
                        Console.WriteLine($"mediantemperaturen för maj månad var: " + String.Format("{0:.00}", days[14]) + "°C");
                        Value = 0;
                        break;

                    case 6: 
                        Array.Copy(days, Copydays, days.Length); // gör en kopia av våran array så vi inte rör runt i den riktiga
                        Array.Sort(Copydays);
                        for (int i = 0; i < 31; i++) // printar ut all adagar i en sorterad ordning
                        {
                            Console.WriteLine("Dag " + (i + 1) + ": " + String.Format("{0:.00}", Copydays[i]) + "°C");
                        }
                        Value = 0;
                        break;

                    case 7:
                        Array.Copy(days, Copydays, days.Length); // gör en kopia av våran array så vi inte rör runt i den riktiga
                        double Valueminmax = 0;
                        int overunder = 0;

                        Console.WriteLine($"1. Vill du ha ett värde över det du skriver in?");
                        Console.WriteLine($"2. Eller ett värde under?");
                        int.TryParse(Console.ReadLine(), out overunder);
                        if (overunder == 1)
                        {
                            Console.WriteLine($"skriv in det värdet du söker efter");
                            double.TryParse(Console.ReadLine(), out Valueminmax);
                            for (int i = 0; i < 31; i++)
                            {
                                if (days[i] > Valueminmax)
                                {
                                    Console.WriteLine("Dag " + (i + 1) + ": " + String.Format("{0:.00}", days[i]) + "°C");
                                }
                            }
                            break;
                        }
                        if (overunder == 2)
                        {
                            Console.WriteLine($"skriv in det värdet du söker efter");
                            double.TryParse(Console.ReadLine(), out Valueminmax);
                            for (int i = 0; i < 31; i++)
                            {
                                if (days[i] < Valueminmax)
                                {
                                    Console.WriteLine("Dag " + (i + 1) + ": " + String.Format("{0:.00}", days[i]) + "°C");
                                }
                            }
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case 8:
                        int daylooking = 0; // bara å printa ut dagen å väret i arrayen
                        Console.WriteLine($"skriv in det dagen du är nyfiken på");
                        int.TryParse(Console.ReadLine(), out daylooking);
                        Console.WriteLine($"Dag {daylooking} var det {days[daylooking - 1]:F2}°C");
                        break;

                    case 9:
                        double mostcommontemp = 0;
                        int maxnumber = 0;
                        Array.Copy(days, Copydays, days.Length); // gör en kopia av våran array så vi inte rör runt i den riktiga

                        for (int l = 0; l < 31; l++) // vi behöver kolla värdet av varje värde mot varje värde så vi nestar en loop för att först kolla dag 1 med alla andra, sen dag 2 osv
                        {
                            Copydays[l] = Math.Round(Copydays[l]);
                            Console.WriteLine($"{Copydays[l]}");
                        }

                        for (int i = 0; i < 31; i++)
                        {   
                            double TempTest = Copydays[i];
                            int currentcounter = 0;

                            for (int u = 0; u < 31; u++)
                            {
                                if (Copydays[u] == TempTest )
                                {
                                    currentcounter++;
                                }
                            }
                            if (currentcounter > maxnumber)
                            {
                                maxnumber = currentcounter;
                                mostcommontemp = TempTest;
                            }
                        }

                        if (maxnumber == 0)
                        {
                            Console.WriteLine($"ingen temperatur var den lika");
                            break;
                        }

                        else
                            Console.WriteLine($"vanligast förekommande tempreaturen för maj månad var {mostcommontemp}°C");
                            break;

                    case 0:
                                break;

                            default:
                                break;
                            }
                        }
                }
            }
        }



