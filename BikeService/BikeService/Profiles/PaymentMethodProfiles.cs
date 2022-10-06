using AutoMapper;
using BikeService.DTOs.Response;
using BikeService.Models;

namespace BikeService.Profiles
{
    public class PaymentMethodProfiles : Profile
    {
        public PaymentMethodProfiles()
        {
            CreateMap<PaymentMethod, PaymentResponse>();
        }
    }
}
