namespace BikeService.Models
{
    public partial class Motorbike
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; } = null!;
        public int CustomerId { get; set; }
        public int IsActived { get; set; }
    }
}
