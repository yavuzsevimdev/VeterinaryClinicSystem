using AutoMapper;
using VeterinaryClinic.Business.Dtos.AppointmentDtos;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.Business.Mapping
{
    public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<CreateAppointmentDto, Appointment>();
            CreateMap<Appointment, ResultAppointmentDto>();
            CreateMap<Appointment, GetAppointmentByIdDto>();
            CreateMap<UpdateAppointmentDto, Appointment>();
        }
    }
}
