using Domain.Models;
using Repository.Context;
using System.Linq;

namespace Repository.EntyRepository
{
    public class SolicitacaoRepository : Repository<Solicitacao>
    {
        public SolicitacaoRepository(BaseContext context) : base(context)
        {
        }

        public Solicitacao GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
