using AutoMapper;
using BikeService.Models;
using BikeService.Models.Request;

namespace BikeService.Profiles
{
    public class DistrictProfiles : Profile
    {
        public DistrictProfiles()
        {
            CreateMap<CategoryRequest, Category>();
        }
    }
}
// dotnet ef dbcontext scaffold Name=DefaultConnection Pomelo.EntityFrameworkCore.MySql --output-dir Models --context-dir Data --namespace BikeService.Models --context-namespace BikeService.Data --context MyDbContext -f --no-onconfiguring