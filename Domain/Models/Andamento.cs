using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tickts.Domain.Models
{
    public class Andamento
    {
        #region Propriedades
        [Key]
        [Required, Column("id")]
        public int IdAndamento { get; set; }

        [Required, Column("descricao"), MaxLength(400)]
        public string Descricao { get; set; }

        [Required, Column("data_andamento")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime DataAndamento { get; set; }
        #endregion

        #region Relacionamentos
        public int? Solicitacao_Id { get; set; }
        public Solicitacao Solicitacao { get; set; }
        #endregion

        #region Mapeamento
        public static void Map(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Andamento>();
            map.HasKey(x => x.IdAndamento);
            map.Property(x => x.IdAndamento).ValueGeneratedOnAdd();

            //1:N
            map.HasOne(x => x.Solicitacao).WithMany(x => x.Andamentos).HasForeignKey(x => x.Solicitacao_Id).OnDelete(DeleteBehavior.Cascade);
        }
        #endregion

    }
}
