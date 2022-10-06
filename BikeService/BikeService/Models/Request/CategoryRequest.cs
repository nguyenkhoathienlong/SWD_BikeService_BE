namespace BikeService.Models.Request
{
    public class CategoryRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ulong? IsService { get; set; }
    }
}
