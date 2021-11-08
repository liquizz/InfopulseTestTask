using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebPortal.Database.Models
{
    public class Orders
    {
        #nullable enable
        public Orders()
        {
            
        }
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDateCreated { get; set; }
        public Customers? CustomerId { get; set; }
        public float? FinalPrice { get; set; }
        public OrderComments? OrderComments { get; set; }
        public OrderStatuses? OrderStatuses { get; set; }
    }
}