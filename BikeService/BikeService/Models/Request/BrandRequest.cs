using System.ComponentModel.DataAnnotations;

namespace BikeService.Models.Request
{
    public class BrandRequest
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
