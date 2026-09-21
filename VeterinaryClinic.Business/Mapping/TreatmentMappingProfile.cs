using AutoMapper;
using VeterinaryClinic.Business.Dtos.TreatmentDtos;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.Business.Mapping
{
    public class TreatmentMappingProfile : Profile
    {
        public TreatmentMappingProfile()
        {
            CreateMap<CreateTreatmentDto, Treatment>();
            CreateMap<UpdateTreatmentDto, Treatment>();
            CreateMap<Treatment, ResultTreatmentDto>();
            CreateMap<Treatment, GetTreatmentByIdDto>();
        }
    }
}
