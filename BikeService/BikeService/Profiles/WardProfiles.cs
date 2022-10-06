using AutoMapper;
using BikeService.Models.Response;
using BikeService.Models;

namespace BikeService.Profiles
{
    public class WardProfiles : Profile
    {
        public WardProfiles()
        {
            CreateMap<Ward, WardReponse>();
        }
    }
}
