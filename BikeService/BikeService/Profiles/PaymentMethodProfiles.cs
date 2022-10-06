using AutoMapper;
using BikeService.Models;
using BikeService.Models.Response;

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
