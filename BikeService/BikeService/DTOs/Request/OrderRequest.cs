namespace BikeService.DTOs.Request
{
    public class OrderResponse
    {
        public DateOnly Date { get; set; }
        public float Total { get; set; }
        public int StoreId { get; set; }
        public int MotorbikeId { get; set; }
    }
}
