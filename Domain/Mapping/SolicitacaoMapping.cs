using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace Domain.Mapping
{
    public class SolicitacaoMapping : Profile
    {
        public SolicitacaoMapping()
        {
            CreateMap<Solicitacao, SolicitacaoListDTO>()
                .ForMember(dest => dest.QuantSolicitacao, ori => ori.MapFrom(x => x.Andamentos.Count))
                .ReverseMap();
        }
    }
}
