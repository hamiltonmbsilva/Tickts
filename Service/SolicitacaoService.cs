using Repository.EntyRepository;

namespace Service
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
