using AutoMapper;
using VeterinaryClinic.Business.Dtos.AnimalDtos;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.Business.Mapping
{
    public class AnimalMappingProfile : Profile
    {
        public AnimalMappingProfile()
        {
            CreateMap<CreateAnimalDto, Animal>();
            CreateMap<Animal, ResultAnimalDto>();
            CreateMap<UpdateAnimalDto, Animal>();
            CreateMap<Animal, GetAnimalByIdDto>();
        }
    }
}
