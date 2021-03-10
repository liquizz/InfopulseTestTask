using System.ComponentModel.DataAnnotations;

namespace WebPortal.Database.Models
{
    public class OrdersProducts
    {
        [Key]
        public int OrderProductId { get; set; }
        public Orders Order { get; set; }
        public Products Product { get; set; }
        public int ProductQuantity { get; set; }
    }
}