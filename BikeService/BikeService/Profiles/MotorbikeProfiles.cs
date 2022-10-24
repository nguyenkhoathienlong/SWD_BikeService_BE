using AutoMapper;
using BikeService.Models;
using BikeService.Models.Request;

namespace BikeService.Profiles
{
    public class MotorbikeProfiles : Profile
    {
        public MotorbikeProfiles()
        {
            CreateMap<MotorbikeRequest, Motorbike>();
        }
    }
}
