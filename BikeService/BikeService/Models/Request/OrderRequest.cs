namespace BikeService.Models.Request
{
    public class OrderRequest
    {
        public DateOnly Date { get; set; }
        public float Total { get; set; }
        public int StoreId { get; set; }
        public int MotorbikeId { get; set; }
    }
}
