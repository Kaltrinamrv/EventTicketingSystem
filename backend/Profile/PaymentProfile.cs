using AutoMapper;
using backend.Entities;
using backend.Models;

namespace backend.Profile
{
    public class PaymentProfile : AutoMapper.Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentDto>().ReverseMap();
        }
    }
}


