using Microsoft.EntityFrameworkCore;

namespace WebPortal.Database.Models
{
    interface IWebPortalContext
    {
        
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
        public DbSet<OrdersStatuses> OrdersStatuses { get; set; }

    }
}