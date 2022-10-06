using AutoMapper;
using BikeService.Models.Response;
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
