using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AndamentoController : ControllerBase
    {
        private readonly AndamentoService _serviceAndamento;
        private readonly IMapper _mapper;
        public AndamentoController(IMapper mapper, AndamentoService serviceAndamento)
        {
            _mapper = mapper;
            _serviceAndamento = serviceAndamento;            
        }
    }
}
