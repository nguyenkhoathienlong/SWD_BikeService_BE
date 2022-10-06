using AutoMapper;
using BikeService.Models;
using BikeService.Models.Response;

namespace BikeService.Profiles
{
    public class OrderDetailsProfiles : Profile
    {
        public OrderDetailsProfiles()
        {
            CreateMap<OrderDetail, OrderDetailsResponse>();
        }
    }
}
