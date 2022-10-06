using AutoMapper;
using BikeService.Models;
using BikeService.Models.Request;

namespace BikeService.Profiles
{
    public class StoreProfiles : Profile
    {
        public StoreProfiles()
        {
            CreateMap<StoreRequest, Store>();
        }
    }
}
