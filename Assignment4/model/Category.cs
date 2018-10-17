using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4.model
{
    [Table("categories")]
    public class Category
    {
    
        [Key, Column("categoryid")] public int Id { get; set; }

        [Column("categoryname")] public string Name { get; set; }

        [Column("description")] public string Description { get; set; }

        public ICollection<Product> Products { get;  set; }
    }
}