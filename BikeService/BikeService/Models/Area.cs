namespace BikeService.Models
{
    public partial class Area
    {
        public Area()
        {
            Wards = new HashSet<Ward>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Ward> Wards { get; set; }
    }
}
