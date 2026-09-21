using AutoMapper;
using VeterinaryClinic.Business.Dtos.PaymentDtos;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.Business.Mapping
{
    public class PaymentMappingProfile : Profile
    {
        public PaymentMappingProfile()
        {
            CreateMap<CreatePaymentDto, Payment>();
            CreateMap<UpdatePaymentDto, Payment>();
            CreateMap<Payment, ResultPaymentDto>();
            CreateMap<Payment, GetPaymentByIdDto>();
        }
    }
}
