using System.ComponentModel.DataAnnotations;

namespace BikeService.Models.Request
{
    public class WardRequest
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int DistrictId { get; set; }
        [Required]
        public int AreaId { get; set; }
    }
}
