using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickts.Domain.Enum;

namespace Tickts.Domain.DTO
{
    public class SolicitacaoListDTO
    {
        public string Solicitante { get; set; }

        
        public DateTime DataCadastro { get; set; }

        
        public EnumStatus Status { get; set; }

    }
}
