using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickts.Repository.EntyRepository;

namespace Tickts.Service
{
    public class SolicitacaoService
    {
        private readonly SolicitacaoRepository _repositorySolicitacao;

        public SolicitacaoService(SolicitacaoRepository repositorySolicitacao)
        {
            _repositorySolicitacao = repositorySolicitacao;
        }
    }
}
