using AutoMapper;
using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

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

        //GET: api/cliente 
        [HttpGet]
        public ActionResult<Solicitacao> GetAll()
        {
            try
            {
                var solicitacao = _serviceSolicitacao.BuscarTodosSolicitacao();

                var SolicitacaoDTO = _mapper.Map<List<SolicitacaoListDTO>>(solicitacao);

                return Ok(SolicitacaoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/cliente 
        [HttpGet("solicitados")]
        public ActionResult<Solicitacao> GetAllSolicitados()
        {
            try
            {
                int i;

                int quant = 0;

                IList<Solicitacao> vinteSolicitacao = new List<Solicitacao>();

                var solicitacaoTotal = _serviceSolicitacao.BuscarTodosSolicitacao().OrderByDescending(x => x.Id).ToList();

                foreach (Solicitacao solicitacao in solicitacaoTotal)
                {
                    for (i = 0; i < 20; i++)
                    {
                        vinteSolicitacao.Add(solicitacao);
                        break;

                    }

                    quant = quant + 1;

                    if(quant == 20)
                        break;
                }

                var SolicitacaoDTO = _mapper.Map<List<SolicitacaoListDTO>>(vinteSolicitacao);

                return Ok(SolicitacaoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/cliente/1        
        [HttpGet("{id}")]
        public ActionResult<Solicitacao> GetById(int id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var solicitacao = _serviceSolicitacao.BuscarPeloId(id);

                if (solicitacao == null)
                {
                    return NotFound();
                }

                var SolicitacaoDTO = _mapper.Map<SolicitacaoListDTO>(solicitacao);

                return Ok(SolicitacaoDTO);              

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST: api/cliente
        [HttpPost]
        public ActionResult<Solicitacao> Post([FromBody] Solicitacao solicitacao)
        {
            try
            {               

                if (solicitacao.Solicitante == null)
                {
                    return NotFound("Não é possivel salvar um cliente com o CPF vazio !");
                }               


                var retorno = _serviceSolicitacao.SalvarSolicitacao(solicitacao);

                if (retorno == null)
                {
                    return BadRequest("Erro ao Salvar");
                }

                return Ok(solicitacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //PUT: api/cliente
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Solicitacao solicitacao, int id)
        {
            try
            {
                var idSolicitacao = _serviceSolicitacao.BuscarPeloId(id);


                idSolicitacao.Solicitante = solicitacao.Solicitante;
                idSolicitacao.Status = solicitacao.Status;
                idSolicitacao.TextoSolicitacao = solicitacao.TextoSolicitacao;

                var result = _serviceSolicitacao.AlterarSolicitacao(idSolicitacao);

                if (result == null)
                    return BadRequest("Solicitação não encontrado!");

                var SolicitacaoDTO = _mapper.Map<List<SolicitacaoListDTO>>(result);

                return Ok(SolicitacaoDTO);
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //DELETE: api/cliente/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _serviceSolicitacao.ExcluirSolicitacao(id);

                return Ok("Usúario deletado com sucesso!");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
