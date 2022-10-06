using AutoMapper;
using BikeService.Models;
using BikeService.Models.Response;

namespace BikeService.Profiles
{
    public class AreaProfiles : Profile
    {
        public AreaProfiles()
        {
            //Source -> Destination
            CreateMap<Area, AreaResponse>();
        }
    }
}
