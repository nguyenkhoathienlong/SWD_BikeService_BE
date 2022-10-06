namespace BikeService.Models.Request
{
    public class CustomerRequest
    {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
    }
}
