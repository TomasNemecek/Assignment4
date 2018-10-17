using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4.model
{
    [Table("products")]
    public class Product
    {
        
        [Key, Column("productid")] public int Id { get; set; }
        
        [Column("productname")] public string Name { get; set; }
        
        [Column("unitprice")] public int UnitPrice { get; set; }
        
        [Column("unitsinstock")] public int UnitsInStock { get; set; }
        
        [Column("quantityperunit")] public string QuantityPerUnit { get; set; }
        
        [Column("categoryid")] public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}