using Domain.Enum;
using System;

namespace Domain.DTO
{
    public class SolicitacaoListDTO
    {
        public int Id { get; set; }
        public string Solicitante { get; set; }
        public DateTime DataCadastro { get; set; }       
        public EnumStatus Status { get; set; }
        public string TextoSolicitacao { get; set; }
        public string QuantSolicitacao { get; set; }

    }
}
