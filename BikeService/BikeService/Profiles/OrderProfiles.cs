using AutoMapper;
using BikeService.Models;
using BikeService.DTOs.Response;

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
