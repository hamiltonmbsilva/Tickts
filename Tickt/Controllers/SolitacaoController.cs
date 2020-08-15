using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        private readonly SolicitacaoService _serviceSolicitacao;
        private readonly IMapper _mapper;
        public SolicitacaoController(IMapper mapper, SolicitacaoService serviceSolicitacao)
        {
            _mapper = mapper;
            _serviceSolicitacao = serviceSolicitacao;
        }
    }
}
