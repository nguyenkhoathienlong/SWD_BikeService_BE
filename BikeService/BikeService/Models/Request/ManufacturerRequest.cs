using System.ComponentModel.DataAnnotations;

namespace BikeService.Models.Request
{
    public class ManufacturerRequest
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
