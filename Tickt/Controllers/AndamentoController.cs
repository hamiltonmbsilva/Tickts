using AutoMapper;
using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;

namespace Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AndamentoController : ControllerBase
    {
        private readonly AndamentoService _serviceAndamento;
        private readonly SolicitacaoService _serviceSolicitacao;

        private readonly IMapper _mapper;
        public AndamentoController(IMapper mapper, AndamentoService serviceAndamento, SolicitacaoService serviceSolicitacao)
        {
            _mapper = mapper;
            _serviceAndamento = serviceAndamento;
            _serviceSolicitacao = serviceSolicitacao;
        }

        //GET: api/cliente 
        [HttpGet]
        public ActionResult<Andamento> GetAll()
        {
            try
            {
                var andamento = _serviceAndamento.BuscarTodosAndamento();

                var AndamentoDTO = _mapper.Map<List<AndamentoListDTO>>(andamento);

                return Ok(AndamentoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    

        //GET: api/cliente/1        
        [HttpGet("{id}")]
        public ActionResult<Andamento> GetById(int id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var andamento = _serviceAndamento.BuscarPeloId(id);

                if (andamento == null)
                {
                    return NotFound();
                }

                var AndamentoDTO = _mapper.Map<AndamentoListDTO>(andamento);

                return Ok(AndamentoDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/cliente/1        
        [HttpGet("getAll/{id}")]
        public ActionResult<Andamento> GetAllId(int id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var andamento = _serviceAndamento.BuscarTodosPeloId(id);

                if (andamento == null)
                {
                    return NotFound();
                }

                var AndamentoDTO = _mapper.Map<List<AndamentoListDTO>>(andamento);

                return Ok(AndamentoDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST: api/cliente
        [HttpPost]
        public ActionResult<Andamento> Post([FromBody] Andamento andamento)
        {
            try
            {

                if (andamento == null)
                {
                    return NotFound("Não é possivel salvar um andamento vazio !");
                }

                if(andamento.SolicitacaoId == 0)
                {
                    return NotFound("Não é possivel salvar um andamento Com o Id Nulo !");
                }

                var solicitacao = _serviceSolicitacao.BuscarPeloId(andamento.SolicitacaoId);

                if(solicitacao == null)
                    return NotFound("Não é possivel salvar um andamento com ID vazio !");


                var retorno = _serviceAndamento.SalvarAndamento(andamento);

                if (retorno == null)
                {
                    return BadRequest("Erro ao Salvar");
                }

                return Ok(andamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //PUT: api/cliente
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Andamento andamento, int id)
        {
            try
            {
                var andamentos = _serviceAndamento.BuscarPeloId(id);


                andamentos.Descricao  = andamento.Descricao;
                andamentos.DataAndamento = andamento.DataAndamento;


                var result = _serviceAndamento.AlterarAndamento(andamentos);

                if (result == null)
                    return BadRequest("Solicitação não encontrado!");

                var AndamentoDTO = _mapper.Map<AndamentoListDTO>(result);

                return Ok(AndamentoDTO);

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
                _serviceAndamento.ExcluirAndamento(id);

                return Ok("Andamento deletado com sucesso!");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
