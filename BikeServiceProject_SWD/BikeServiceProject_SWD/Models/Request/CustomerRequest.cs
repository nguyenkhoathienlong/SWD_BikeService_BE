using System.ComponentModel.DataAnnotations;

namespace BikeServiceProject_SWD.Models.Request
{
    public class CustomerRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
        [EmailAddress]
        public string? Email { get; set; }
    }
}
