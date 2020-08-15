using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickts.Repository.EntyRepository;

namespace Tickts.Service
{
    public class AndamentoService
    {
        private readonly AndamentoRepository _repositoryAndamento;

        public AndamentoService(AndamentoRepository repositoryAndamento)
        {
            _repositoryAndamento = repositoryAndamento;
        }


    }
}
