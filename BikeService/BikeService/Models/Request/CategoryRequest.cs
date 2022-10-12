using System.ComponentModel.DataAnnotations;

namespace BikeService.Models.Request
{
    public class CategoryRequest
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public ulong? IsService { get; set; }
    }
}
