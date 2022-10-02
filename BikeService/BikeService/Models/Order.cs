namespace BikeService.Models
{
    public partial class Order
    {
        public Order()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public float Total { get; set; }
        public int StoreId { get; set; }
        public int MotorbikeId { get; set; }

        public virtual Store Store { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
