
using System.ComponentModel.DataAnnotations;

namespace BikeService.Models.Request
{
    public class AreaRequest
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
