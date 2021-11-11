using System;

namespace ProductsService.Logic.DTOModels
{
    public class GetProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string SizeName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public DateTime ProductDate { get; set; }
        public int ProductDescriptionId { get; set; }
        public string Description { get; set; }
    }
}
