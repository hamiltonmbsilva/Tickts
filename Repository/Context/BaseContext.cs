using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tickts.Domain.Models;

namespace Tickts.Repository.Context
{
    public class BaseContext : IdentityDbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
            Database.EnsureCreated();            
        }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           
            Andamento.Map(builder);
            Solicitacao.Map(builder);
            
        }
        
        public DbSet<Andamento> andamentos { get; set; }
        public DbSet<Solicitacao> solitacoes { get; set; }
        
    }
}
