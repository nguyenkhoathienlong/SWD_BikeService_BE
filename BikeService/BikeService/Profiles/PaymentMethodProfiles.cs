using AutoMapper;
using BikeService.Models;
using BikeService.Models.Request;

namespace BikeService.Profiles
{
    public class PaymentMethodProfiles : Profile
    {
        public PaymentMethodProfiles()
        {
            CreateMap<PaymentMethodRequest, PaymentMethod>();
        }
    }
}
