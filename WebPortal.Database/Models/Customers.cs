using System;
using System.ComponentModel.DataAnnotations;

namespace WebPortal.Database.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}