using AutoMapper;
using BikeServiceProject_SWD.Models;
using BikeServiceProject_SWD.Models.Request;

namespace BikeServiceProject_SWD.Profiles
{
    public class OrderDetailsProfiles : Profile
    {
        public OrderDetailsProfiles()
        {
            CreateMap<OrderDetailsRequest, OrderDetail>();
        }
    }
}
