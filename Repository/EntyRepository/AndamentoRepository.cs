using System.Linq;
using Tickts.Domain.Models;
using Tickts.Repository.Context;

namespace Tickts.Repository.EntyRepository
{
    public class AndamentoRepository : Repository<Andamento>
    {
        public AndamentoRepository(BaseContext context) : base(context)
        {
        }

        public Andamento GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.IdAndamento == id);
        }
    }
}
