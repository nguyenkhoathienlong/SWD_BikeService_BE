using AutoMapper;
using BikeService.DTOs.Response;
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
