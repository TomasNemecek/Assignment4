using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4.model
{
    [Table("orders")]
    public class Order
    {
        [Key, Column("orderid")] public int Id { get; set; }

        [Column("orderdate")] public DateTime? Date { get; set; } = new DateTime();

        [Column("requireddate")] public DateTime? Required { get; set; } = new DateTime();

        [Column("shippeddate")] public DateTime? ShippedDate { get; set; }

        [Column("freight")] public int Freight { get; set; }

        [Column("shipname")] public string ShipName { get; set; }

        [Column("shipaddress")] public string ShipAddress { get; set; }

        [Column("customerid")] public string CustomerId { get; set; }

        [Column("employeeid")] public int EmployeeId { get; set; }

        [Column("shipcity")] public string ShipCity { get; set; }

        [Column("shippostalcode")] public string ShipPostalCode { get; set; }

        [Column("shipcountry")] public string ShipCountry { get; set; }
        
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}