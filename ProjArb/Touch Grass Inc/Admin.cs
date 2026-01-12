using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace TouchGrassInc
{
    public class Admin
    {
        private const string username = "admin";
        private const string password = "admin";

        public void Login(Inventory myStore)
        {
            // Asks for username and password
            Console.Clear();
            Console.Write("Ange användarnamn: "); 
            string usernameInput = Console.ReadLine();
            Console.Write("Ange lösenord: "); 
            string passwordInput = Console.ReadLine();


            // If either admin or username (or both) are wrong
            if (usernameInput != username || passwordInput != password)
            {
                Console.WriteLine("Felaktiga uppgifter.");
                return;
            }
            RunAdminMenu(myStore);
        }

        // If both username and password are correct
        private void RunAdminMenu(Inventory myStore)
        {
            bool adminLogin = true;
            while (adminLogin)
            {
                // Admin menu which allows adding/removing or products from the inventory
                Console.Clear();
                Console.WriteLine("[*]---Adminpanelen---[*]");
                Console.WriteLine("[*]1. Lägg till produkt i lager---[*]");
                Console.WriteLine("[*]2. Ta bort produkt-------------[*]");
                Console.WriteLine("[*]3. Visa Lager------------------[*]");
                Console.WriteLine("[*]4. Logga ut--------------------[*]");
                Console.WriteLine();
                Console.Write("Vad vill du göra? (1-4): ");
                if(int.TryParse(Console.ReadLine(), out int adminPanel))
                {
                    Console.Clear();

                    switch (adminPanel)
                    {
                        case 1:

                            // Asks for the ID of new product
                            int newId;
                            while (true)
                            {
                                // Checks if there is already a product with that ID
                                Console.Write("Ange ID för nya produkten: "); 
                                if (int.TryParse(Console.ReadLine(), out newId))
                                {
                                    if (myStore.GetProductById(newId) == null) break;
                                    Console.WriteLine("ID finns redan i systemet.");
                                }
                                else
                                {
                                    Console.WriteLine("Ogiltigt format");
                                }
                            }
                            // Name of new product
                            Console.Write("Ange Namn för nya produkten: "); 
                            string newName = Console.ReadLine();

                            decimal newPrice;
                            while (true)
                            {
                                // Pris of new product
                                Console.Write("Ange Pris för nya produkten: ");
                                if (decimal.TryParse(Console.ReadLine(), out newPrice) && newPrice >= 0)
                                {
                                    break;
                                }

                                Console.WriteLine("Ogiltig pris.");
                            }

                            int newQuantity;
                            while (true)
                            {
                                // Quantity of new product
                                Console.Write("Ange Lagerantal: ");
                                if (int.TryParse(Console.ReadLine(), out newQuantity) && newQuantity >= 0) break;
                                Console.WriteLine("Ogiltigt antal.");
                            }

                            // Combines all values and creates the new product
                            myStore.AddOrUpdateProductSTOCK(new Product { Id = newId, Name = newName, Price = newPrice, Quantity = newQuantity, Amount = 0 });

                            Console.Clear();
                            Console.WriteLine($"{newName} har lagts till i lagret.");
                            Console.Write("Tryck på valfri tangent för att fortsätta.");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:

                            Console.Clear();
                            myStore.DisplayStock();
                            Console.WriteLine("");
                            Console.WriteLine("Välj produkt ID av den varan du vill ta bort: ");
                            // Removes a product based on the ID put into the terminal
                            if (int.TryParse(Console.ReadLine(), out int removeId))
                            {
                                var removeInput = myStore.GetProductById(removeId);
                                // Amount
                                Console.Write("Hur många?: ");
                                if (int.TryParse(Console.ReadLine(), out int amountRemoved))
                                {
                                    if (amountRemoved <= removeInput.Quantity)
                                    {
                                        removeInput.Quantity -= amountRemoved;
                                    }
                                    else
                                    {
                                        // If more than the inventory (to avoid negative numbers) or not a number
                                        Console.WriteLine("Ogiltigt antal.");
                                        break;
                                    }
                                }

                            }
                            break;

                        case 3:
                            
                            // Shows the stock
                            myStore.DisplayStock();
                            Console.Write("Tryck på valfri tangent för att fortsätta.");
                            Console.ReadKey();
                            break;
                        case 4:
                            adminLogin = false;
                            break;

                        default:
                            Console.WriteLine("Ogiltigt svar.");
                            break;

                    }

                }
                else
                {
                    Console.WriteLine("Ogiltigt svar.");
                }

                    }


        }
    }}