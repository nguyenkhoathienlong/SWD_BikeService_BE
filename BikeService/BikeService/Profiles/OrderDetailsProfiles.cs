using AutoMapper;
using BikeService.DTOs.Response;
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
