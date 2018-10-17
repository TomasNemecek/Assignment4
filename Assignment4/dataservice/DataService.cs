using System;
using System.Collections.Generic;
using System.Linq;
using Assignment4.database;
using Assignment4.model;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.dataservice
{
    public class DataService : IDataService
    {
        protected readonly NorthWindContext Context = new NorthWindContext();

        //Orders
        public Order GetOrder(int id)
        {
            return Context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .ThenInclude(prod => prod.Category)
                .SingleOrDefault<Order>(e => e.Id == id);
        }

        public ICollection<Order> GetOrdersByShipName(string shipName)
        {
            return Context.Orders.Where(e => e.ShipName == shipName).ToList();
        }

        public ICollection<Order> GetOrders()
        {
            return Context.Orders
                .Include(o => o.OrderDetails)
                .ToList();
        }

        //Order details
        public ICollection<OrderDetails> GetOrderDetailsByOrderId(int orderId)
        {
            return Context.OrderDetails
                .Include(e => e.Order)
                .Include(e => e.Product)
                .ThenInclude(prd => prd.Category)
                .Where(e => e.OrderId == orderId)
                .ToList();
        }

        public ICollection<OrderDetails> GetOrderDetailsByProductId(int productId)
        {
            var result = Context.OrderDetails
                .Where(e => e.ProductId == productId)
                .OrderBy(e => e.Order.Date)
                .Include(e => e.Order)
                .ToList();

            return result;
        }

        //Product
        public Product GetProduct(int id)
        {
            return Context.Products
                .Include(prod => prod.Category)
                .SingleOrDefault(e => e.Id == id);
        }

        public ICollection<Product> GetProductByName(string name)
        {
            return Context.Products
                .Include(prod => prod.Category)
                .Where(p => p.Name.Contains(name)).ToList();
        }

        public ICollection<Product> GetProductByCategory(int categoryId)
        {
            return Context.Products
            .Include(prod => prod.Category)         
            .Where(p => p.CategoryId == categoryId).ToList();
        }

        //Category
        public ICollection<Category> GetCategories()
        {
            return Context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return Context.Categories.SingleOrDefault(e => e.Id == id);
        }

        public Category CreateCategory(string name, string description)
        {
            try
            {
                var max = Context.Categories.Max(cat => cat.Id) + 1;
                var category = new Category { Id = max, Name = name, Description = description };
                Context.Categories.Add(category);
                Context.SaveChanges();

                return category;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}");
            }

            return null;
        }

        public bool UpdateCategory(int id, string name, string description)
        {
            try {
                var category = Context.Categories.SingleOrDefault(c => c.Id == id);

                if (category != null) {
                    category.Name = name;
                    category.Description = description;
                    
                    Context.Categories.Update(category);
                    Context.SaveChanges();
                    
                    return true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}");
            }

            return false;
        }

        public bool DeleteCategory(int id)
        {
            try {
                var category = Context.Categories.SingleOrDefault(c => c.Id == id);

                if (category != null) {
                    Context.Categories.Remove(category);
                    Context.SaveChanges();
                    
                    return true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}");
            }

            return false;
        }
    }
}