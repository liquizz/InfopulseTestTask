using System;

namespace WebPortal.Logic.DTOModels
{
    public class CreateProductDTO
    {
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime ProductDate { get; set; }
        public string ProductDescription { get; set; }
        public int ProductSizeId { get; set; }
    }
}