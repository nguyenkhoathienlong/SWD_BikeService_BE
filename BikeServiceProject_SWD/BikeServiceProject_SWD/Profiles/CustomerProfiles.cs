using AutoMapper;
using BikeServiceProject_SWD.Models;
using BikeServiceProject_SWD.Models.Request;

namespace BikeServiceProject_SWD.Profiles
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
