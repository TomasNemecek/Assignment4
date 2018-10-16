using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment4.database;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthWindContext())
            {
                
                Console.WriteLine("Products:");
                foreach (var el in db.Products.Take(10)) 
                {
                    Console.WriteLine($"{el.Name}  ({el.Category.Name})"); 
//                                      $", Prod: {el.Product.Name} ({el.Product.Category.Name})");
                }
            }
            
            Console.WriteLine("Press any key to close");
            Console.ReadKey();

        }
    }
}
