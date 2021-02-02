using System.ComponentModel.DataAnnotations;

namespace WebPortal.Database.Models
{
    public class OrderComments
    {
        [Key]
        public int OrderCommentId { get; set; }
        public string Comment { get; set; }
    }
}