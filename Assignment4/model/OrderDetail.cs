using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4.model
{
    [Table("orderdetails")]
    public class OrderDetail
    {
        //Composite key setup in context 
        //TODO change all mapping to context?
        [Column("orderid")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Column("productid")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Column("unitprice")] public int UnitPrice { get; set; }

        [Column("quantity")] public int Quantity { get; set; }

        [Column("discount")] public int Discount { get; set; }
    }
}