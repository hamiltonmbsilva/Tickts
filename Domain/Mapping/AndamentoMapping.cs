using AutoMapper;
using Tickts.Domain.DTO;
using Tickts.Domain.Models;

namespace Tickts.Domain.Mapping
{
    public class AndamentoMapping : Profile
    {
        public AndamentoMapping()
        {
            CreateMap<AndamentoListDTO, Andamento>().ReverseMap();
        }
    }
}
