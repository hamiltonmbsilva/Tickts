using Domain.Models;
using Microsoft.EntityFrameworkCore;
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
        
        public IQueryable<Andamento> GetAllId(int id)
        {
            return GetAll()
                .Include(x => x.Solicitacao)
                .Where(x => x.SolicitacaoId == id)
                .OrderByDescending(x => x.Solicitacao.Id);
        }
    }
}
