
using System.ComponentModel.DataAnnotations;

namespace BikeServiceProject_SWD.Models.Request
{
    public class AreaRequest
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
