namespace BikeService.Models.Request
{
    public class MotorbikeRequest
    {
        public string LicensePlate { get; set; } = null!;
        public int CustomerId { get; set; }
        public ulong? IsActived { get; set; }
    }
}
