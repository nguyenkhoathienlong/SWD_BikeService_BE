using AutoMapper;
using BikeService.Models;
using BikeService.Models.Request;

namespace BikeService.Profiles
{
    public class PaymentProfiles : Profile
    {
        public PaymentProfiles()
        {
            CreateMap<PaymentRequest, Payment>();
        }
    }
}
