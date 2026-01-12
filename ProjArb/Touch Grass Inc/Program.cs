
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System;


namespace TouchGrassInc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creates instances of Inventory and Cart
            Inventory myStore = new Inventory(); 
            Cart myCart = new Cart();


            // Default products
            myStore.AddOrUpdateProductSTOCK(new Product { Id = 1, Name = "Trådlös Mus", Price = 299, Quantity = 50, Amount = 50 });
            myStore.AddOrUpdateProductSTOCK(new Product { Id = 2, Name = "Mekaniskt Tangentbord", Price = 899, Quantity = 30, Amount = 30 });
            myStore.AddOrUpdateProductSTOCK(new Product { Id = 3, Name = "Gamingheadset", Price = 549, Quantity = 25, Amount = 25 });
            myStore.AddOrUpdateProductSTOCK(new Product { Id = 4, Name = "Webbkamera HD", Price = 450, Quantity = 40, Amount = 40 });
            myStore.AddOrUpdateProductSTOCK(new Product { Id = 5, Name = "USB-C Hub", Price = 320, Quantity = 100, Amount = 100 });


            while (true)
            {
                Console.WriteLine("[*]Shopping App----[*]");
                Console.WriteLine("[1]Bläddra---------[*]");
                Console.WriteLine("[2]Visa varukorg---[*]");
                Console.WriteLine("[3]Admin login-----[*]");
                Console.WriteLine("[4]Exit------------[*]");
                Console.Write("");
                Console.Write("Vad vill du göra? (1-4): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {   
                    case 1:
                        //  Opens the shop (takes both myStore and myCart so both quantity and amount can be altered)
                        myCart.ShopUser(myStore, myCart);
                        break;
                    case 2:
                        // Shows the cart and allows the user to modify it
                        myCart.ViewCart(myStore, myCart); 
                        break;
                    case 3:
                        // Admin login, admin panel
                        Admin userAdmin = new Admin();
                        userAdmin.Login(myStore);
                        break;
                    case 4:
                        // Exit
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ogiltigt svar.");
                        Console.Write("Tryck på valfri tangent för att fortsätta.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    
                    } 
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltigt svar.");
                    Console.Write("Tryck på valfri tangent för att fortsätta.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
