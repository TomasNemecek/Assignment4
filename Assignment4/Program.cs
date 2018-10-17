using System;
using System.Linq;
using Assignment4.database;
using Assignment4.dataservice;
using Assignment4.model;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {


            var service = new DataService();
            var order = service.GetOrder(10248);
            Console.WriteLine($"Id: {order.Id}, Date: {order.Date}, ShipDate: {order.ShippedDate}");
            //
            
//            var prod = service.GetProduct(1);
//             Console.WriteLine($"Id: {prod.Id}");

//            using (var db = new NorthWindContext())
//            {
//                ShowOrders(db);
//            }

                //                ShowProducts(db);
                //                ShowOrderDetails(db);


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

        private static void ShowOrders(NorthWindContext db)
        {
            Console.WriteLine("Orders:");
            foreach (var el in db.Orders.Take(10))
            {
                Console.WriteLine($"{el.Id}  ({el.Date})");
            }
        }

    }
}
