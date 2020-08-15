using Domain.Models;
using Repository.Context;
using System.Linq;

namespace Repository.EntyRepository
{
    public class AndamentoRepository : Repository<Andamento>
    {
        public AndamentoRepository(BaseContext context) : base(context)
        {
        }

        public Andamento GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
