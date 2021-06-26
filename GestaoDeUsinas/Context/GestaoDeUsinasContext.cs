using GestaoDeUsinas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeUsinas.Context
{
    public class GestaoDeUsinasContext : DbContext
    {
        public DbSet<Usina> Usinas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        public GestaoDeUsinasContext(DbContextOptions<GestaoDeUsinasContext> options) : base (options)
        {

        }
    }
}
