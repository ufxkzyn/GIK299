namespace Lektion2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tal1 = 10;
            int tal2 = 20;
            int tal3 = 30;
            int summa = 0;
            int räknare = 1;

            Console.WriteLine("Beräknar summan av tre tal...");

            while (räknare <= 3)
            {
                if (räknare == 1)
                    summa += tal1;
                if (räknare == 2)
                    summa += tal2;
                if (räknare == 3)
                    summa += tal3;

                räknare = räknare + 1;
            }

            Console.WriteLine("Summan av talen är: " + summa);
        }
    }
}
