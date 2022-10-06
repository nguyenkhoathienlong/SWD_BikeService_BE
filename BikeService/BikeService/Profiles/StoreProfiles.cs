using AutoMapper;
using BikeService.Models;
using BikeService.Models.Response;

namespace BikeService.Profiles
{
    public class StoreProfiles : Profile
    {
        public StoreProfiles()
        {
            CreateMap<Store, StoreResponse>();
        }
    }
}
