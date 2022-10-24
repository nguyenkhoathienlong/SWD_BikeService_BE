using System.ComponentModel.DataAnnotations;

namespace BikeService.Models.Request
{
    public class MotorbikeRequest
    {
        [Required]
        [RegularExpression(@"^\d{2}-[A-Z]\d{1}\s\d{4,5}$",
         ErrorMessage = "LicensePlate are not match (xx-Xx xxxxx). x is digits, X is character.")]
        public string LicensePlate { get; set; } = null!;
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public ulong? IsActived { get; set; }
    }

    public partial class MotorbikeCustomer
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string LicensePlate { get; set; }

    }
}
