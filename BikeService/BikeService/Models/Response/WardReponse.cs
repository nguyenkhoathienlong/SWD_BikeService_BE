namespace BikeService.Models.Response
{
    public class WardReponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DistrictId { get; set; }
        public int AreaId { get; set; }
    }
}
