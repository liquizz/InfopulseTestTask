using System;
using System.ComponentModel.DataAnnotations;

namespace WebPortal.Database.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDateCreated { get; set; }
        public Customers CustomerId { get; set; }
        public OrderComments OrderComments { get; set; }
    }
}