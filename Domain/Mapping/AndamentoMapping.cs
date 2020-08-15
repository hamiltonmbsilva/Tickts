using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace Domain.Mapping
{
    public class AndamentoMapping : Profile
    {
        public AndamentoMapping()
        {
            CreateMap<AndamentoListDTO, Andamento>().ReverseMap();
        }
    }
}
