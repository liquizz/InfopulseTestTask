using System.ComponentModel.DataAnnotations;

namespace WebPortal.Database.Models
{
    public class ProductDescriptions
    {
        [Key]
        public int ProductDescriptionId { get; set; }
        public string ProductDescription { get; set; }
    }
}