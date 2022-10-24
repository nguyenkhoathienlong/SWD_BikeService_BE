using AutoMapper;
using BikeService.Models;
using BikeService.Models.Request;

namespace BikeService.Profiles
{
    public class ManufacturerProfiles : Profile
    {
        public ManufacturerProfiles()
        {
            CreateMap<ManufacturerRequest, Manufacturer>();
        }
    }
}
