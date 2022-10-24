using System.ComponentModel.DataAnnotations;

namespace BikeService.Models.Request
{
    public class OrderRequest
    {
        [Required]
        [RegularExpression(@"^\d{2}[/]\d{2}[/]\d{4}$",
         ErrorMessage = "Format Date (dd/mm/yyyy).")]
        public DateOnly Date { get; set; }
        [Required]
        public float Total { get; set; }
        [Required]
        public int StoreId { get; set; }
        [Required]
        public int MotorbikeId { get; set; }
    }
}
