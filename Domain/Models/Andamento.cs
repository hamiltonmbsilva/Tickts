using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("andamento")]
    public class Andamento
    {
        #region Propriedades
        [Key]
        [Required, Column("id")]
        public int Id { get; set; }

        [Required, Column("descricao"), MaxLength(400)]
        public string Descricao { get; set; }

        [Required, Column("data_andamento")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime DataAndamento { get; set; }
        #endregion

        #region Relacionamentos
        [Required, Column("Solicitacao_id")]
        public int SolicitacaoId { get; set; }
        public Solicitacao Solicitacao { get; set; }
        #endregion

        #region Mapeamento
        public static void Map(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Andamento>();
            map.HasKey(x => x.Id);
            map.Property(x => x.Id).ValueGeneratedOnAdd();

            //1:N
            map.HasOne(x => x.Solicitacao).WithMany(x => x.Andamentos).HasForeignKey(x => x.SolicitacaoId).OnDelete(DeleteBehavior.Cascade);
        }
        #endregion

    }
}
