using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickts.Domain.Models;
using Tickts.Repository.Context;

namespace Tickts.Repository.EntyRepository
{
    public class SolicitacaoRepository : Repository<Solicitacao>
    {
        public SolicitacaoRepository(BaseContext context) : base(context)
        {
        }

        public Solicitacao GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.IdSolicitante == id);
        }
    }
}
