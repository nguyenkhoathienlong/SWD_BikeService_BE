using AutoMapper;
using BikeService.Models.Response;
using BikeService.Models;

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
