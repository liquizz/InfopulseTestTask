using System;
using System.Collections.Generic;

namespace WebPortal.Logic.DTOModels
{
    public class CreateOrderDTO
    {
        public DateTime orderDate { get; set; }
        public int customerId { get; set; }
        public int statusId { get; set; }
        public int totalCost { get; set; }
        public List<ProductsListDTO> productsList { get; set; }
    }
}