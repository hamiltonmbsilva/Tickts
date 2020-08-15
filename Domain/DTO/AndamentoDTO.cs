using System;

namespace Domain.DTO
{
    public class AndamentoListDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAndamento { get; set; }
        public SolicitacaoListDTO Solicitacao { get; set; }

    }
}
