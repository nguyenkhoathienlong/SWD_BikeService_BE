using AutoMapper;
using BikeServiceProject_SWD.Models;
using BikeServiceProject_SWD.Models.Request;

namespace BikeServiceProject_SWD.Profiles
{
    public class DistrictProfiles : Profile
    {
        public DistrictProfiles()
        {
            CreateMap<DistrictRequest, District>();
        }
    }
}
// dotnet ef dbcontext scaffold Name=DefaultConnection Pomelo.EntityFrameworkCore.MySql --output-dir Models --context-dir Data --namespace BikeService.Models --context-namespace BikeService.Data --context MyDbContext -f --no-onconfiguring