using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace TouchGrassInc
{
    public class Cart
    {

        // List of items in the user's shopping cart
        public List<Product> CartItems {get; set;} = new List<Product>();

        // When this is called, it uses an integer (in this case, user input) and attempts to find a matching ID
        public Product GetProductById(int id)
        {
            return CartItems.Find(p => p.Id == id); 
        }

        // The shopping system
        public void ShopUser(Inventory myStore, Cart myCart)
        {
            Console.Clear();
            
            while (true)
            {
                Console.WriteLine("[*]1. Handla---[*]");
                Console.WriteLine("[*]2. Backa----[*]");
                Console.Write("Vad vill du göra? (1-2): ");
     

                if (int.TryParse(Console.ReadLine(), out int buyOrBack))
            {
                    switch (buyOrBack)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("[*]Lagret---[*]");
                            myStore.DisplayStock();
                            Console.WriteLine("");
                            Console.Write("Välj vad du vill köpa genom att ange ID (ange 0 för att återvända): ");
                            if (int.TryParse(Console.ReadLine(), out int wareChoice))
                            {
                                // Checks for an ID of the same value as the input
                                var selectedProduct = myStore.GetProductById(wareChoice);
                                if (selectedProduct != null && selectedProduct.Quantity > 0) // Checks if the product exists and if it's in stock
                                {
                                    // The user picks the quantity they want of the selected product
                                    Console.Write("Ange antal (ange 0 för att återvända): ");
                                    if (int.TryParse(Console.ReadLine(), out int howMany))
                                    {
                                        if (howMany >= 1 && howMany <= selectedProduct.Quantity)
                                        {
                                            selectedProduct.Quantity -= howMany;
                                            // Updates the cart 
                                            myCart.AddOrUpdateProduct(new Product 
                                        {
                                            Id = selectedProduct.Id,
                                            Name = selectedProduct.Name,
                                            Price = selectedProduct.Price,
                                            Amount = howMany
                                        });

                                        Console.Clear();
                                        Console.WriteLine($"{howMany}st {selectedProduct.Name} har lagts till i varukorgen.");
                                        Console.Write("Tryck på valfri tangent för att fortsätta.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        }
  
                                    }
                                    // Return to menu
                                    else if (howMany == 0)
                                    {
                                        Console.Clear();
                                        break;
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
                                // Return to menu
                                if (wareChoice == 0)
                                {
                                    Console.Clear();
                                    break;
                                }
                                else if (selectedProduct == null || selectedProduct.Quantity < 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Ogiltigt svar.");
                                    Console.Write("Tryck på valfri tangent för att fortsätta.");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                            }
                            break;
                        case 2:
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Ogiltigt svar.");
                            break;
                    }
                    break;
            }
            }
        }
                
               

        // This allows the cart to be updated by adding, increasing, decreasing product/product quantity (amount)
        public void AddOrUpdateProduct(Product newProduct) 
        {
            var existingProductCart = CartItems.Find(p => p.Id == newProduct.Id);

            if (existingProductCart != null)
            {
                existingProductCart.Amount += newProduct.Amount;
            }
            else
            {
                CartItems.Add(newProduct);
            }
        }

        // Allows the user to check their cart and remove wares
        public void ViewCart(Inventory myStore, Cart myCart) 
        {
            // Checks if cart is empty
            if (CartItems.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Din kundvagn är tom!");
                return;
            }
            Console.Clear();
            Console.WriteLine("Din kundvagn innehåller följande varor:");
            myCart.DisplayCart();
            decimal totalAmount = 0;
            decimal totalAmountFinal = 0;
            foreach (var price in CartItems)
            {
                totalAmount = price.Amount * price.Price;
                totalAmountFinal += totalAmount;
            }
            Console.WriteLine($"Totalt pris: {totalAmountFinal} kr");
            Console.WriteLine();
            Console.WriteLine("[*]Vad vill du göra?------------[*]");
            Console.WriteLine("[1]Ta bort en vara--------------[*]");
            Console.WriteLine("[2]Ta bort alla varor-----------[*]");
            Console.WriteLine("[3]Exit-------------------------[*]");
            Console.Write("Vad vill du göra? (1-3): ");
            // User chooses what they wish to do
            string inputCart;
            int.TryParse(Console.ReadLine(), out int choiceCart);
            switch (choiceCart)
            {
                case 1:
                    if (CartItems.Count != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Välj produkt ID av den varan du vill ta bort: ");
                        myCart.DisplayCart();
                        int removeID;
                        int.TryParse(Console.ReadLine(), out removeID);
                        var removeInput = myStore.GetProductById(removeID);
                        // Goes through the list of IDs and checks if there is a product with an amount over 2 
                        bool carTAboveTwo = CartItems.Find(p => p.Amount >= 2) != null;
                        // Checks if the cart has more than 2 of the selected product 
                        if (carTAboveTwo == true)
                        {
                            // The user is then allowed to select how many of the selected product they would like to remove
                            Console.Write("Hur många?: ");
                            if (int.TryParse(Console.ReadLine(), out int amountRemoved))
                            { 
                                // Removes that amount from the cart and re-adds it to the inventory/stock
                                removeInput.Amount -= amountRemoved;
                                removeInput.Quantity += amountRemoved;

                                var removeMoreCart = myCart.GetProductById(removeInput.Id);
                                removeMoreCart.Amount -= amountRemoved;

                                Console.Clear();
                                Console.WriteLine($"{amountRemoved} st {removeInput.Name} har tagits bort från varukorgen.");
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Ogiltigt svar.");
                                break;
                            }
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Din varukorg är tom.");
                    }
                    break;

                case 2:
                    // If the user chooses to remove all wares
                    foreach (var item in myCart.CartItems)
                    {
                        // As every item in the cart is looped through, the amount of that item in the cart is re-added onto the stock
                        var storeProduct = myStore.GetProductById(item.Id);
                        if (storeProduct != null)
                        {
                            storeProduct.Quantity += item.Amount;
                        }
                    }
                    myCart.CartItems.Clear();
                    Console.Clear();
                    Console.WriteLine("Alla varor har tagits bort från din kundvagn.");
                    Console.Write("Tryck på valfri tangent för att fortsätta.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                // Exit
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        // Lists every item in the user's cart
        public void DisplayCart()
        {
            foreach (var item in CartItems)
            {
                Console.WriteLine($"ID: {item.Id} | Namn: {item.Name} | Styckpris:{item.Price} SEK | Antal: {item.Amount} | Totalpris: {item.Price*item.Amount} SEK");
            }

        }
    }
}