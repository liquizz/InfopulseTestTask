using System;
using System.Collections.Generic;

namespace WebPortal.Logic.DTOModels
{
    public class CreateOrderDTO
    {
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public int TotalCost { get; set; }
        public List<ProductsListDTO> ProductsList { get; set; }
    }
}