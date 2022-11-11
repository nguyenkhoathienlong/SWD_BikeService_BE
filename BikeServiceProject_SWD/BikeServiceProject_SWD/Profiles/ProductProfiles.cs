using AutoMapper;
using BikeServiceProject_SWD.Models;
using BikeServiceProject_SWD.Models.Request;

namespace BikeServiceProject_SWD.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<ProductRequest, Product>();
        }
    }
}
