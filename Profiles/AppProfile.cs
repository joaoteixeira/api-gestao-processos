using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Entities;
using AutoMapper;

namespace ApiGestaoProcessos.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<ProcessoDto, Processo>()
                .ForMember(
                    dest => dest.Situacao,
                    opt => opt.MapFrom(src => "Aberto")
                );

            CreateMap<ProcessoUpdateDto, Processo>();

            CreateMap<ClienteDto, Cliente>();
        }
    }
}
