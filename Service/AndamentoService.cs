using Repository.EntyRepository;

namespace Service
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
