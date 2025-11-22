using System;
using System.ComponentModel.Design;
using System.Diagnostics.SymbolStore;
using System.Net.NetworkInformation;

namespace Labb2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool j = true;
            while (j == true)
            {
                Console.WriteLine("1. Beräkna windchill-faktor");
                Console.WriteLine("2. Avlusta");
                    int svar;
                    int.TryParse(Console.ReadLine(), out svar); // gör om svaret till liten bokstav ifall man skriver stor.

                    switch (svar)
                    {
                    case 1:
                            Console.WriteLine("Fyll i utomhustemperaturen i celsius:");
                            double T = Convert.ToDouble(Console.ReadLine()); // alla convert to double används för att kunna läsa in decimaltal från användaren och omvandla det till double datatyp.
                            Console.WriteLine("Vill du fylla i vindhastigheten med m/s eller km/h?");
                            Console.WriteLine("Skriv 1 för m/s eller 2 för km/h:");
                            double VH = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Fyll i vindhastigheten:");
                            double V = Convert.ToDouble(Console.ReadLine());
                            if (VH == 1)
                            {
                                V = V * 3.6; //om användare valde m/s så omvandlar vi det till km/h genom att multiplicera med 3.6.
                            }
                            if (VH == 2)
                            {
                                V = V; //om användaren valde km/h så gör vi ingen omvandling.
                            }

                            double WCT = 13.12 + 0.6215 * T - 11.37 * (Math.Pow(V, 0.16)) + 0.3965 * T * (Math.Pow(V, 0.16)); // me stupid, använde ai för hjälp å få rätt på >=, försökte först med || å intervaller

                            if (WCT > 0)
                            {
                            Console.WriteLine($"Det kommer kännas som att det är {WCT:F2} grader utomhus, inte alls farligt!");
                            }
                            else if (WCT >= -25)
                            {
                                Console.WriteLine($"Det kommer kännas som att det är {WCT:F2} grader utomhus, kallt."); // :F2 är för å säga att vi vill ha 2 decimaler.
                            }

                            else if (WCT >= -35)
                            {
                                Console.WriteLine($"Det kommer kännas som att det är {WCT:F2} grader utomhus, Mycket Kallt."); // :F2 är för å säga att vi vill ha 2 decimaler.
                            }

                            else if (WCT >= -60)
                            {
                                Console.WriteLine($"Det kommer kännas som att det är {WCT:F2} grader utomhus, Risk för frostskada."); // :F2 är för å säga att vi vill ha 2 decimaler.
                            }

                            else
                            {
                                Console.WriteLine($"Det kommer kännas som att det är {WCT:F2} grader utomhus, Stor risk för frostskada."); // :F2 är för å säga att vi vill ha 2 decimaler.
                            }
                            break;

                    case 2:
                            j = false;
                            break;

                    default:
                            Console.WriteLine("ogiltigt val! testa igen!");

                            break;
                    }
            }
        }
    }
}

/*Skapa en Console-applikation som ni döper till WindchillCalc eller liknande. I filen Program.cs finns klassen Program. I klassen program finns main-metoden fördefinierad. Main-metoden är startpunkten för programmet.
Deklarera variabler som ska innehålla värden för windchilltemperatur (WCT), temperatur och vindhastighet av datatypen double (för att kunna hålla decimaltal).
Skriv ut ett meddelande till användaren i konsolen så de vet vad de ska göra. T.ex. ”fyll i utomhustemperaturen i celsius”.
Använd en lämplig metod i Console-klassen för att läsa in det värde från konsolen som användaren matar in och spara det till en passande variabel som ni deklarerat i början av programmet.
Skriv ut en rad i konsolen med instruktioner för användaren: ”Fyll i vindhastighet” (ange även om användaren ska mata in det i m/s eller km/h.
Använd en lämplig metod i Console-klassen för att läsa in det värde från konsolen som användaren matar in och spara det till en passande variabel som ni deklarerat i början av programmet.
När ni har de data som behövs ska ni använda WCT-formeln för att beräkna Windchill-faktorn. Tilldela resultatet av beräkningen till den variabel ämnad för detta som ni deklarerat i början av programmet.
Använd lämplig metod i Console-klassen för att skriva ut en mening med vad WCT blev i konsolen och formatera antalet decimaler (välj en eller två decimaler) med hjälp av String.Format().*/