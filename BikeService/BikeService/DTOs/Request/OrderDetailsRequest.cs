namespace BikeService.DTOs.Request
{
    public class OrderDetailsResponse
    {
        public int ProductId { get; set; }
        public float OriginalPrice { get; set; }
        public float PromotionPrice { get; set; }
        public int Quantity { get; set; }
    }
}
