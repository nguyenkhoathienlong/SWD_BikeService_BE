namespace BikeService.Models.Request
{
    public class OrderDetailsRequest
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public float OriginalPrice { get; set; }
        public float PromotionPrice { get; set; }
        public int Quantity { get; set; }
    }
}
