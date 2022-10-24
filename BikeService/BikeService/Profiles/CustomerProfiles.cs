using AutoMapper;
using BikeService.Models;
using BikeService.Models.Request;

namespace BikeService.Profiles
{
    public class CustomerProfiles : Profile
    {
        public CustomerProfiles()
        {
            //Source -> Destination
            CreateMap<CustomerRequest, Customer>();
        }
    }
}
