using Domain.Enum;
using System;

namespace Domain.DTO
{
    public class SolicitacaoListDTO
    {
        public string Solicitante { get; set; }
        public DateTime DataCadastro { get; set; }
        public EnumStatus Status { get; set; }

    }
}
