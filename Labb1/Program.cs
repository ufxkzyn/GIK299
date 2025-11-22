namespace Labb0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int flighth = 07;
            int flightm = 25;
            int clockh = 0;
            int clockm = 0;

            int NYhour = 10;
            int NYmin = 10;

            int STHLMhour = 14;
            int STHLMmin = 03;

            int zoneDiff = 06;
            int Resan;


            Console.WriteLine("*************************************************************");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Välkommen till flygtidsberäknaren!");
            Console.WriteLine("Vilket flyg vill du se detaljerad information om? (svara med siffra)");
            Console.WriteLine("1. Stockholm - New York");
            Console.WriteLine("2. New York - Stockholm");
            Console.WriteLine("3. Avsluta programmet");
            Console.Write("Skriv ditt val här: "); // använder write inte writeline för att inte få en ny rad
            int.TryParse(Console.ReadLine(),out Resan); // konverterar strängen från användaren till en integer så att jag kan avnända i if satserna
            Console.WriteLine("Du valde: " + Resan);
            Console.Clear();

            if (Resan == 1)
            { 
                clockh = STHLMhour - zoneDiff + flighth; // enkel matte för att räkna ut ankomsttiden
                clockm = STHLMmin + flightm;
                Console.WriteLine("*************************************************************");
                Console.WriteLine("");
                Console.WriteLine($"Avgångstiden från Stockholm är {STHLMhour:00}:{STHLMmin:00}"); // $ används så jag kan använda {} för att få in variabler i strängen
                Console.WriteLine($"Ankomsttiden till New York är {clockh:00}:{clockm:00}"); // :00 används för att alltid visa två siffror
                Console.WriteLine("");
                Console.WriteLine("*************************************************************");
                Console.WriteLine("");
                Console.WriteLine("Programmet avslutas nu. Tack för att du använde flygtidsberäknaren!");
                Console.WriteLine("");
                Thread.Sleep(2000); // väntar 2 sekunder innan programmet avslutas
                Environment.Exit(0);
            }

            if (Resan == 2)
            {
                clockh = NYhour + zoneDiff + flighth; // enkel matte för att räkna ut ankomsttiden
                clockm = NYhour + flightm;
                Console.WriteLine("*************************************************************");
                Console.WriteLine("");
                Console.WriteLine($"Avgångstiden från New York är {NYhour}:{NYmin}"); // $ används så jag kan använda {} för att få in variabler i strängen
                Console.WriteLine($"Ankomsttiden till Stockholm är {clockh}:{clockm}"); // :00 används för att alltid visa två siffror
                Console.WriteLine("");
                Console.WriteLine("*************************************************************");
                Console.WriteLine("");
                Console.WriteLine("Programmet avslutas nu. Tack för att du använde flygtidsberäknaren!");
                Thread.Sleep(2000); // väntar 2 sekunder innan programmet avslutas
                Environment.Exit(0);
            }

            if (Resan == 3)
            { 
                Console.WriteLine("Programmet avslutas nu. Tack för att du använde flygtidsberäknaren!");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
    }
}
