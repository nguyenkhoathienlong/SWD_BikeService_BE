using System.ComponentModel.DataAnnotations;

namespace BikeServiceProject_SWD.Models.Request
{
    public class BrandRequest
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
