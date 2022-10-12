using System.ComponentModel.DataAnnotations;

namespace BikeService.Models.Request
{
    public class DistrictRequest
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
