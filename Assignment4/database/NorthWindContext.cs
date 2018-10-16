using Assignment4.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment4.database
{
    class NorthWindContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;database=northwind;Username=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Order details
            base.OnModelCreating(modelBuilder);

            buildProductConfig(modelBuilder);

            modelBuilder.Entity<OrderDetail>()
                .HasKey(d => new {d.OrderId, d.ProductId});

            modelBuilder.Entity<OrderDetail>()
                .HasOne(d => d.Order)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDERDETAIL_ORDER");

            modelBuilder.Entity<OrderDetail>()
                .HasOne(d => d.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDERDETAIL_PRODUCT");
        }

        private void buildProductConfig(ModelBuilder builder)
        {
            builder.Entity<Product>().ToTable("products");
            builder.Entity<Product>().HasKey(e => e.Id);
            builder.Entity<Product>().Property(e => e.Id).HasColumnName("productid");
            builder.Entity<Product>().Property(e => e.Name).HasColumnName("productname");
            builder.Entity<Product>().Property(e => e.CategoryId).HasColumnName("categoryid");
            builder.Entity<Product>().Property(e => e.UnitPrice).HasColumnName("unitprice");
            builder.Entity<Product>().Property(e => e.UnitsInStock).HasColumnName("unitsinstock");
            builder.Entity<Product>().Property(e => e.QuantityPerUnit).HasColumnName("quantityperunit");
            
            builder.Entity<Product>().HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_PRODUCT_CATEGORY");
            
        }

    }
}