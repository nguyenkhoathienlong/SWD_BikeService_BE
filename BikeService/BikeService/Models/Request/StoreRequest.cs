using System.ComponentModel.DataAnnotations;

namespace BikeService.Models.Request
{
    public class StoreRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        public int WardId { get; set; }
    }
}
