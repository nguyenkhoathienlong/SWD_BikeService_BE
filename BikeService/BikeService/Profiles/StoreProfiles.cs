using AutoMapper;
using BikeService.DTOs.Response;
using BikeService.Models;

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
