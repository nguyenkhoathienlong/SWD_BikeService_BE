namespace BikeService.Models.Response
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public float Total { get; set; }
        public int StoreId { get; set; }
        public int MotorbikeId { get; set; }
    }
}
