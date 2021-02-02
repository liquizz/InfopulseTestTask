using System.ComponentModel.DataAnnotations;

namespace WebPortal.Database.Models
{
    public class OrdersStatuses
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}