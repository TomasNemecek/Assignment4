using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4.model
{
    [Table("products")]
    public class Product
    {
        [Column("productid")]
        public int Id { get; set; }

        [Column("productname")]
        public int Name { get; set; }

        [Column("CategoryId")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}