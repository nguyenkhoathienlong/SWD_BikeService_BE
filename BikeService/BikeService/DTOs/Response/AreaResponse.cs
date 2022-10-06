using BikeService.Models;

namespace BikeService.DTOs.Response 
{
    public class AreaResponse
    {
        public string Name { get; set; } = null!;
        public string Ward { get; set; }
    }
}
