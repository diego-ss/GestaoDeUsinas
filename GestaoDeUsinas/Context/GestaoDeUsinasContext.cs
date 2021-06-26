using GestaoDeUsinas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeUsinas.Context
{
    public class GestaoDeUsinasContext : DbContext
    {
        public DbSet<Usina> Usinas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        public GestaoDeUsinasContext(DbContextOptions<GestaoDeUsinasContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //populando a tabela de fornecedores com os valores padrão
            
            modelBuilder.Entity<Fornecedor>().HasData(
                new Fornecedor { Id = 1, Nome = "SOLARIAN" },
                new Fornecedor { Id = 2, Nome = "FUTURA" },
                new Fornecedor { Id = 3, Nome = "CENTRAL GERADORA FAZENDA MODELO" },
                new Fornecedor { Id = 4, Nome = "NOVA MUNDO" },
                new Fornecedor { Id = 5, Nome = "SOLARE" },
                new Fornecedor { Id = 6, Nome = "UNISOL" }
            );
        }
    }
}
