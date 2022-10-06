using AutoMapper;
using BikeService.DTOs.Response;
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
