using System;

namespace WebPortal.Logic.DTOModels
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public float TotalUserSum { get; set; }
        public int TotalOrders { get; set; }
    }
}