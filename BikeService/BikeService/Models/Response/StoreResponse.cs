namespace BikeService.Models.Response
{
    public class StoreResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int WardId { get; set; }
    }
}
