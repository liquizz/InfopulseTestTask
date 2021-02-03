using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPortal.Database.Models;

namespace WebPortal.Database
{
    public interface IWebPortalContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<OrderComments> OrderComments { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrdersProducts> OrdersProducts { get; set; }
        public DbSet<ProductDescriptions> ProductDescriptions { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<ProductSizes> ProductSizes { get; set; }
        public DbSet<OrderStatuses> OrdersStatuses { get; set; }

        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class WebPortalContext : DbContext, IWebPortalContext
    {
        public WebPortalContext()
        {
            
        }

        public WebPortalContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<OrderComments> OrderComments { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrdersProducts> OrdersProducts { get; set; }
        public DbSet<ProductDescriptions> ProductDescriptions { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<ProductSizes> ProductSizes { get; set; }
        public DbSet<OrderStatuses> OrdersStatuses { get; set; }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                //handle with some logger
                return false;
            }

            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderStatuses>().HasData(
                new { StatusId = 1, StatusName = "New"}, 
                new { StatusId = 2, StatusName = "Paid"}, 
                new { StatusId = 3, StatusName = "Shipped"}, 
                new { StatusId = 4, StatusName = "Delivered"}, 
                new { StatusId = 5, StatusName = "Closed"});

            modelBuilder.Entity<ProductSizes>().HasData(
                new { SizeId = 1, SizeName = "Small" },
                new { SizeId = 2, SizeName = "Medium"},
                new { SizeId = 3, SizeName = "Large" });

            modelBuilder.Entity<ProductCategories>().HasData(
                new { CategoryId = 1, CategoryName = "Food" },
                new { CategoryId = 2, CategoryName = "Electronics" },
                new { CategoryId = 3, CategoryName = "Furniture" },
                new { CategoryId = 4, CategoryName = "Shoes" });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=WebPortal; Trusted_Connection=True; MultipleActiveResultSets=true");
        }

    }
}