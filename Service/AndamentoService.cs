using Domain.Models;
using Repository.EntyRepository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class AndamentoService
    {
        private readonly AndamentoRepository _repositoryAndamento;

        public AndamentoService(AndamentoRepository repositoryAndamento)
        {
            _repositoryAndamento = repositoryAndamento;
        }

        public IEnumerable<Andamento> BuscarTodosAndamento()
        {
            try
            {
                var todosAndamentos = _repositoryAndamento.GetAll();
                return todosAndamentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Andamento BuscarPeloId(int id)
        {
            try
            {
                if (id != 0)
                {
                    var andamento = _repositoryAndamento.GetById(id);
                    return andamento;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Andamento SalvarAndamento(Andamento andamento)
        {
            try
            {
                if (andamento == null)
                    throw new Exception("Não é possivel salvar um Andamento vazio");

                _repositoryAndamento.Save(andamento);
                return andamento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Andamento AlterarAndamento(Andamento c)
        {
            try
            {
                if (c == null)
                {
                    throw new Exception("Não é possivel alterar o Andamento vazio");
                }

                _repositoryAndamento.Update(c);

                return c;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExcluirAndamento(int id)
        {
            try
            {
                if (id > 0)
                {
                    var andamento = _repositoryAndamento.GetById(id);

                    if (andamento != null)
                    {
                        _repositoryAndamento.Delete(x => x.Id == id);
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
