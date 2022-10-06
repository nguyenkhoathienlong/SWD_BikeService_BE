namespace BikeService.Models.Request
{
    public class PaymentMethodRequest
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = null!;
    }
}
