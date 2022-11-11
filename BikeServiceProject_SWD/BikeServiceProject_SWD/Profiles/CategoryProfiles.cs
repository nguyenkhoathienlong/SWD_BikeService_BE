using AutoMapper;
using BikeServiceProject_SWD.Models;
using BikeServiceProject_SWD.Models.Request;

namespace BikeServiceProject_SWD.Profiles
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
