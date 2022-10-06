using AutoMapper;
using BikeService.Models.Response;
using BikeService.Models;

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
