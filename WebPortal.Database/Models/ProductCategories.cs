using System.ComponentModel.DataAnnotations;

namespace WebPortal.Database.Models
{
    public class ProductCategories
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}