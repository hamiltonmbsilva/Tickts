using Domain.Models;
using Repository.EntyRepository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class SolicitacaoService
    {
        private readonly SolicitacaoRepository _repositorySolicitacao;

        public SolicitacaoService(SolicitacaoRepository repositorySolicitacao)
        {
            _repositorySolicitacao = repositorySolicitacao;
        }

        public IEnumerable<Solicitacao> BuscarTodosSolicitacao()
        {
            try
            {
                var todasSolicitacao = _repositorySolicitacao.GetAll();
                return todasSolicitacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Solicitacao> BuscarTodosVinteSolicitacao()
        {
            try
            {
                var todasSolicitacao = _repositorySolicitacao.GetAll();
                return todasSolicitacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Solicitacao BuscarPeloId(int id)
        {
            try
            {
                if (id != 0)
                {
                    var solicitacao = _repositorySolicitacao.GetById(id);
                    return solicitacao;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Solicitacao SalvarSolicitacao(Solicitacao solicitacao)
        {
            try
            {
                if (solicitacao == null)
                    throw new Exception("Não é possivel salvar um Solicitacao vazio");

                _repositorySolicitacao.Save(solicitacao);
                 return solicitacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Solicitacao AlterarSolicitacao(Solicitacao c)
        {
            try
            {
                if (c == null)
                {
                    throw new Exception("Não é possivel alterar o Solicitação vazio");
                }         
                       
                _repositorySolicitacao.Update(c);

                return c;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExcluirSolicitacao(int id)
        {
            try
            {
                if (id > 0)
                {
                    var solicitacao = _repositorySolicitacao.GetById(id);

                    if (solicitacao != null)
                    {
                        _repositorySolicitacao.Delete(x => x.Id == id);
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
