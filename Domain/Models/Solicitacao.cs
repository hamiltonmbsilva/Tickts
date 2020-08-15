using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("solitacao")]
    public class Solicitacao
    {
        #region Propriedades
        [Key]
        [Required, Column("id")]
        public int Id { get; set; }

        [Required, Column("solicitante"), MaxLength(255)]
        public string Solicitante { get; set; }

        [Required, Column("data_cadastro")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime DataCadastro { get; set; }        

        [Required, Column("status")]
        public EnumStatus Status { get; set; }

        [Required, Column("texto_solicitacao"), MaxLength(1000)]
        public string TextoSolicitacao { get; set; }
        #endregion

        #region Relacionamentos
        public virtual List<Andamento> Andamentos { get; set; }

        #endregion

        #region Mapeamento
        public static void Map(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Solicitacao>();
            map.HasKey(x => x.Id);
            map.Property(x => x.Id).ValueGeneratedOnAdd();

            //1:N
            map.HasMany(x => x.Andamentos).WithOne(x => x.Solicitacao).HasForeignKey(x => x.SolicitacaoId).OnDelete(DeleteBehavior.Cascade);

        }
        #endregion

    }
}
