namespace BikeService.DTOs.Request
{
    public class StoreRequest
    {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int WardId { get; set; }
    }
}
