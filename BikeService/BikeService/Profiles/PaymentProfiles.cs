using AutoMapper;
using BikeService.DTOs.Response;
using BikeService.Models;

namespace BikeService.Profiles
{
    public class PaymentProfiles : Profile
    {
        public PaymentProfiles()
        {
            CreateMap<Payment, PaymentResponse>();
        }
    }
}
