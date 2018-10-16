using System;
using Assignment4.database;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthWindContext())
            {
                
                ShowProducts(db);
                ShowOrderDetails(db);
            }
            
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        private static void ShowOrderDetails(NorthWindContext db)
        {

            Console.WriteLine("OrderDetails:");
            foreach (var el in db.OrderDetails.Include(d => d.Product).ThenInclude(p => p.Category))
            {
                Console.WriteLine($"Id: {el.OrderId}, Prod: {el.Product.Name} ({el.Product.Category.Name})");
            }
        }

        private static void ShowProducts(NorthWindContext db)
        {
            Console.WriteLine("Products:");
            foreach (var el in db.Products.Include(p => p.Category))
            {
                Console.WriteLine($"{el.Name}  ({el.Category.Name})");
            }
        }


    }
}
