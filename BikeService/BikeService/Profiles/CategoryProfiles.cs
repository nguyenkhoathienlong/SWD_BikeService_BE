using AutoMapper;
using BikeService.Models;
using BikeService.Models.Request;

namespace BikeService.Profiles
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            //Source -> Destination
            CreateMap<CategoryRequest, Category>();
        }
    }
}
