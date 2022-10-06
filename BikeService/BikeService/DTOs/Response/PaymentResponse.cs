namespace BikeService.DTOs.Response
{
    public class PaymentResponse
    {
        public int PaymentMethodId { get; set; }
        public float AmountPaid { get; set; }
        public int OrderId { get; set; }
    }
}
