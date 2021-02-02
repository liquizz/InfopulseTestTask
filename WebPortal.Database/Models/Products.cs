using System;
using System.ComponentModel.DataAnnotations;

namespace WebPortal.Database.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public DateTime ProductDate { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public ProductDescriptions ProductDescription { get; set; }
    }
}