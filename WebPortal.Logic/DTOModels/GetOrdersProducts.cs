using System;

namespace WebPortal.Logic.DTOModels
{
    public class GetOrdersProducts
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string SizeName { get; set; }
        public int ProductQuantity { get; set; }
        public float Price { get; set; }
    }
}