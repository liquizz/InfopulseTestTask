using System.ComponentModel.DataAnnotations;

namespace WebPortal.Database.Models
{
    public class ProductSizes
    {
        [Key]
        public int SizeId { get; set; }
        public string SizeName { get; set; }
    }
}