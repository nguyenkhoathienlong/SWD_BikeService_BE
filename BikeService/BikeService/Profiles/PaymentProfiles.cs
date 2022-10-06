using AutoMapper;
using BikeService.Models.Response;
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
