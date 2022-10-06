namespace BikeService.Models.Request
{
    public class PaymentRequest
    {
        public int Id { get; set; }
        public int PaymentMethodId { get; set; }
        public float AmountPaid { get; set; }
        public int OrderId { get; set; }
    }
}
