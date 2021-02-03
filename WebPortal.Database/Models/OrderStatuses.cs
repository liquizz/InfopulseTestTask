using System.ComponentModel.DataAnnotations;

namespace WebPortal.Database.Models
{
    public class OrderStatuses
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}