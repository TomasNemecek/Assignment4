using System.Collections.Generic;
using Assignment4.model;

namespace Assignment4.dataservice
{
    public class DataService : IDataService
    {
        public Order GetOrder(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Order> GetOrdersByShipName(string shipName)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Order> GetOrders()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<OrderDetails> GetOrderDetailsByOrderId(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<OrderDetails> GetOrderDetailsByProductId(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Product> GetProductByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Product> GetProductByCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Category> GetCategories()
        {
            throw new System.NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public Category CreateCategory(string name, string description)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateCategory(int id, string name, string description)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteCategory(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}