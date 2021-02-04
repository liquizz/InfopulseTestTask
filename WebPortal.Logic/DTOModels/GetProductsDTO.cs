namespace WebPortal.Logic.DTOModels
{
    public class GetProductsDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string SizeName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}