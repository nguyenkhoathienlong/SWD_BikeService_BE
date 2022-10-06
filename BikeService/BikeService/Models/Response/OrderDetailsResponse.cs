namespace BikeService.Models.Response
{
    public class OrderDetailsResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public float OriginalPrice { get; set; }
        public float PromotionPrice { get; set; }
        public int Quantity { get; set; }
    }
}
