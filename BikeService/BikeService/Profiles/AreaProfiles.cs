using AutoMapper;
using BikeService.Models;
using BikeService.Models.Request;

namespace BikeService.Profiles
{
    public class AreaProfiles : Profile
    {
        public AreaProfiles()
        {
            //Source -> Destination
            CreateMap<AreaRequest, Area>();
        }
    }
}
