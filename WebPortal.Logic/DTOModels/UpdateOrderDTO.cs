﻿using System;
using System.Collections.Generic;

namespace WebPortal.Logic.DTOModels
{
    public class UpdateOrderDTO
    {
        public int orderId { get; set; }
        public DateTime orderDate { get; set; }
        public int customerId { get; set; }
        public int statusId { get; set; }
        public int totalCost { get; set; }
        public string comment { get; set; }
        public List<ProductsListDTO> productsList { get; set; }
    }
}