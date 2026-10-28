using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Dtos.Responses;
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

            CreateMap<Cliente, ClienteResponseDto>();

            CreateMap<MarcacaoDto, Marcacao>();

            CreateMap<Marcacao, MarcacaoResponseDto>();

            CreateMap<Processo, ProcessoResponseDto>()
                .ForMember(
                    dest => dest.Etapas,
                    opt => opt.MapFrom(src => src.ProcessosEtapas.OrderBy(x => x.Ordem))
                );

            CreateMap<Etapa, EtapaResponseDto>();

            CreateMap<ProcessoEtapa, ProcessoEtapaResponseDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Etapa.Nome)
                );

            CreateMap<ProcessoEtapaDto, ProcessoEtapa>()
                .ForMember(
                    dest => dest.ProcessoId,
                    opt => opt.Ignore()
                )
                .ForMember(
                    dest => dest.Processo,
                    opt => opt.Ignore()
                )
                .ForMember(
                    dest => dest.Etapa,
                    opt => opt.Ignore()
                );
        }
    }
}
