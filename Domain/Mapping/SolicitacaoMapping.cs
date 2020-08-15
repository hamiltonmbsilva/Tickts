using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace Domain.Mapping
{
    public class SolicitacaoMapping : Profile
    {
        public SolicitacaoMapping()
        {
            CreateMap<SolicitacaoListDTO, Solicitacao>().ReverseMap();
        }
    }
}
