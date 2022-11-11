using AutoMapper;
using BikeServiceProject_SWD.Models;
using BikeServiceProject_SWD.Models.Request;

namespace BikeServiceProject_SWD.Profiles
{
    public class AreaProfiles : Profile
    {
        public AreaProfiles()
        {
            //Source -> Destination
            CreateMap<AreaRequest, Area>();
        }
    }
}
