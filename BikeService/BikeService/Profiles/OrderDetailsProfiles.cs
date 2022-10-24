using AutoMapper;
using BikeService.Models;
using BikeService.Models.Request;

namespace BikeService.Profiles
{
    public class OrderDetailsProfiles : Profile
    {
        public OrderDetailsProfiles()
        {
            CreateMap<OrderDetailsRequest, OrderDetail>();
        }
    }
}
