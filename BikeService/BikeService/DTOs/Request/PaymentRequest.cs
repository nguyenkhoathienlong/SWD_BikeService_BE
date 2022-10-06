namespace BikeService.DTOs.Request
{
    public class PaymentResponse
    {
        public int PaymentMethodId { get; set; }
        public float AmountPaid { get; set; }
        public int OrderId { get; set; }
    }
}
