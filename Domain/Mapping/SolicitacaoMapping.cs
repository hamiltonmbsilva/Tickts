using AutoMapper;
using Tickts.Domain.DTO;
using Tickts.Domain.Models;

namespace Tickts.Domain.Mapping
{
    public class SolicitacaoMapping : Profile
    {
        public SolicitacaoMapping()
        {
            CreateMap<SolicitacaoListDTO, Solicitacao>().ReverseMap();
        }
    }
}
