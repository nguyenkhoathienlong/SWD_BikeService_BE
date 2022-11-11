using System.ComponentModel.DataAnnotations;

namespace BikeServiceProject_SWD.Models.Request
{
    public class CategoryRequest
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public ulong? IsService { get; set; }
    }
}
