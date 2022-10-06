namespace BikeService.DTOs.Response
{
    public class ProductResponse
    {
        public string Name { get; set; } = null!;
        public float Price { get; set; }
        public int? Quantity { get; set; }
        public int ManufacturerId { get; set; }
        public int CategoryId { get; set; }
        public string StoreId { get; set; } = null!;
    }
}
