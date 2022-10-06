using AutoMapper;
using BikeService.Models;
using BikeService.Models.Response;

namespace BikeService.Profiles
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            //Source -> Destination
            CreateMap<Category, CategoryResponse>();
        }
    }
}
