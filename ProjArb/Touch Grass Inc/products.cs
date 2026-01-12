using System;
using System.Collections.Generic;
using System.Text;

namespace TouchGrassInc
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        //Specifically used for stock
        public int Quantity { get; set; } 
        
        // Specifically used for cart
        public int Amount { get; set; } 


    }

    public class Inventory
    {
        // List that holds the products in stock
        public List<Product> Stock {get; set;} = new List<Product>();

        // Adds products to the stock or updates products already in stock (quantity)
        public void AddOrUpdateProductSTOCK(Product newProduct) 
        {
            var existingProduct = Stock.Find(p => p.Id == newProduct.Id);

            if (existingProduct != null)
            {
                existingProduct.Quantity += newProduct.Quantity;
            }
            else
            {
                Stock.Add(newProduct);
            }

        }
        // Searches for an ID that matches with input (int id)
        public Product GetProductById(int id)
        {
            return Stock.Find(p => p.Id == id);
        }


        // Allows the entire stock to be displayed by looping through each item
        public void DisplayStock()
        {
            foreach (var item in Stock)
            {
                Console.WriteLine($"ID: {item.Id} | Namn: {item.Name} | Pris {item.Price} SEK | I lager: {item.Quantity}"); 
            }
            if (Stock.Count == 0)
            {
                Console.WriteLine("Largret är tomt.");
            }
        }
    }
}
