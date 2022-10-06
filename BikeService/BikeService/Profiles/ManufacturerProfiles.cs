using AutoMapper;
using BikeService.Models.Response;
using BikeService.Models;

namespace BikeService.Profiles
{
    public class ManufacturerProfiles : Profile
    {
        public ManufacturerProfiles()
        {
            CreateMap<Manufacturer, ManufacturerResponse>();
        }
    }
}
