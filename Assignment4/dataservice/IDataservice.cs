using System;
using System.Collections;
using System.Collections.Generic;
using Assignment4.model;

namespace Assignment4.dataservice
{
    public interface IDataService
    {
        //Order
        Order GetOrder(int id);

        ICollection<Order> GetOrdersByShipName(string shipName);

        ICollection<Order> GetOrders();

        //Order Details
        ICollection<OrderDetails> GetOrderDetailsByOrderId(int orderId);

        ICollection<OrderDetails> GetOrderDetailsByProductId(int productId);
        
        //Product
        Product GetProduct(int id);

        ICollection<Product> GetProductByName(string name);

        ICollection<Product> GetProductByCategory(int categoryId);

        //Category 
        ICollection<Category> GetCategories();

        Category GetCategory(int id);

        Category CreateCategory(string name, string description);

        bool UpdateCategory(int id, string name, string description);

        bool DeleteCategory(int id);
    }
}