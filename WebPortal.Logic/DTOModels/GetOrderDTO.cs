using System;

namespace WebPortal.Logic.DTOModels
{
    public class GetOrderDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float FinalPrice { get; set; }
        public string StatusName { get; set; }
        public DateTime OrderDateCreated { get; set; }
    }
}