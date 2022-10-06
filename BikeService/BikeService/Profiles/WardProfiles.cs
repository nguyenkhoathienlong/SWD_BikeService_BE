using AutoMapper;
using BikeService.Models;
using BikeService.Models.Response;

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
