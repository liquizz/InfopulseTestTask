using System.ComponentModel.DataAnnotations;

namespace WebPortal.Database.Models
{
    public class ProductSizes
    {
        [Key]
        public int SizeId { get; set; }
        public int SizeName { get; set; }
    }
}