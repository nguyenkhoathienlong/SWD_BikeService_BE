namespace BikeService.DTOs.Request
{
    public class CategoryCreate
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ulong? IsService { get; set; }
    }
}
