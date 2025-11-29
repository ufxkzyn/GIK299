namespace Labb3
{
    internal class Program
    {
        /*public static Array Days()
        { 
        
        }
        */



        public static double NextDouble(Random rnd, double min, double max) // https://stackoverflow.com/questions/22046831/random-numbers-with-decimals
        {
            max = 33.2;
            min = -24.1;

            return rnd.NextDouble() * (max - min) + min;
        }


        
        static void Main(string[] args)
        {
            Random rnd = new Random();
            double TempDag = NextDouble(rnd, -24.1, 33.2);
            Console.WriteLine($"{TempDag:F2}");
        }
        

    }   
}


/* 
*********************Kravspecifikation****************************
Som meteorolog vill jag kunna få en lista över temperaturdata för varje dag i maj
Som meteorolog vill jag kunna hämta medeltemperaturen i maj så att jag kan få en
översikt över månadens genomsnittliga temperatur.
 Som meteorolog vill jag kunna hitta den dag i maj med den högsta temperaturen och
veta vilken temperatur det var för att kunna identifiera den varmaste dagen.
Som meteorolog vill jag kunna hitta den dag i maj med den lägsta temperaturen och
veta vilken temperatur det var för att kunna identifiera den kallaste dagen.
Som meteorolog vill jag kunna få mediantemperaturen för maj månad för att förstå
temperaturfördelningen över månaden.
Som meteorolog vill jag kunna sortera temperaturerna stigande eller fallande ordning
så att jag kan analysera temperaturvariationerna.
Som meteorolog vill jag kunna filtrera temperaturdata för maj månad för att visa bara
de dagar då temperaturen överstiger en viss tröskelvärde, så att jag kan identifiera
varma dagar.
Som meteorolog vill jag kunna kunna skriva in en dag i maj och få utskrivet den dagens
temp samt temperaturen dagen före och efter.
Som meteorolog vill jag kunna få ut den vanligast förekommande temperaturen i maj


Ditt jobb är nu att skapa en applikation där ni realiserar Disas vision baserat på hennes user stories ovan.
Skapa en konsolapplikation som hanterar temperaturdata för maj månad med hjälp av en statisk array.

************Mål***************
Deklarera och använda en array.
Generera temperaturdata med Random.
Beräkna medel, median, max, min, sortering och filtrering.
Förstå begränsningarna med en statisk array.

********************Följande ska finnas med i applikationen:******************************
En klass som innehåller temperaturer och lämpliga metoder, tänk på att klassnamn skrivs som subjekt/objekt (t.ex. TemperatureCalculator) och metodnamn som verb (t.ex. FindMinTemperature)
Instansiera objekt av ovanstående klass i Program.cs och Main-metoden och anropa metoderna från denna klass via objektet.
En array (statisk array) med så många index som det finns dagar i maj
Populera arrayen med element genom att instansiera ett objekt av Random-klassen och använd dess Next()-metod. Skicka med intervallen för temperaturerna till parameterlistan. 
Lösningar för alla user stories ovan.
Tänk på din läsare! Skriv ut både dagen (datumet) och temperaturen i utskriften på ett sätt som är lämpligt för meteorologen.
Använd valfria loopar
*/