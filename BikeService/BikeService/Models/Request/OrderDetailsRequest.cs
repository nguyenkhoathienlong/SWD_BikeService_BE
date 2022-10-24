using System.ComponentModel.DataAnnotations;

namespace BikeService.Models.Request
{
    public class OrderDetailsRequest
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public float OriginalPrice { get; set; }
        [Required]
        public float PromotionPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
