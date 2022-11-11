using System.ComponentModel.DataAnnotations;

namespace BikeServiceProject_SWD.Models.Request
{
    public class DistrictRequest
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
