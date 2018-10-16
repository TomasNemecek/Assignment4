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

        [Column("orderdate")] public DateTime Date { get; set; }

        [Column("requireddate")] public DateTime Required { get; set; }

        [Column("shippeddate")] public DateTime ShippedDate { get; set; }

        [Column("freight")] public int Freight { get; set; }

        [Column("shipname")] public string ShipName { get; set; }

        [Column("shipaddress")] public string ShipCity { get; set; }


        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}