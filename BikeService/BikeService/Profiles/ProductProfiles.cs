using AutoMapper;
using BikeService.DTOs.Response;
using BikeService.Models;

namespace BikeService.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<Product, ProductResponse>();
        }
    }
}
