namespace BikeService.Models
{
    public partial class Motorbike
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; } = null!;
        public int CustomerId { get; set; }
        public ulong? IsActived { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
