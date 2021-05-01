using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using KenKata.Entities;

#nullable disable

namespace KenKata.Data
{
    public partial class SqlDbProductsContext : DbContext
    {
        public SqlDbProductsContext()
        {
        }

        public SqlDbProductsContext(DbContextOptions<SqlDbProductsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }        
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppinCartItem> ShoppinCartItems { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.OrderTotal).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_OrderDetails_DrinkId");

                entity.HasIndex(e => e.OrderId, "IX_OrderDetails_OrderId");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId);
            });
            

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.LongDescription).IsRequired();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShortDescription)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__BrandI__245D67DE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Pictur__236943A5");
            });

            modelBuilder.Entity<ShoppinCartItem>(entity =>
            {
                entity.HasKey(e => e.ShoppingCartItemId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShoppinCartItems)
                    .HasForeignKey(d => d.ProductId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
