using AutoMapper;
using BikeService.Models;
using BikeService.Models.Response;

namespace BikeService.Profiles
{
    public class OrderProfiles : Profile
    {
        public OrderProfiles()
        {
            CreateMap<Order, OrderResponse>();
        }
    }
}
