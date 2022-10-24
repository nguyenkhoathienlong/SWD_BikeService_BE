using AutoMapper;
using BikeService.Models;
using BikeService.Models.Request;

namespace BikeService.Profiles
{
    public class WardProfiles : Profile
    {
        public WardProfiles()
        {
            CreateMap<WardRequest, Ward>();
        }
    }
}
