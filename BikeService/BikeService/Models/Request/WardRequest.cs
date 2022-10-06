namespace BikeService.Models.Request
{
    public class WardRequest
    {
        public string Name { get; set; } = null!;
        public int DistrictId { get; set; }
        public int AreaId { get; set; }
    }
}
