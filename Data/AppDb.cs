using Microsoft.EntityFrameworkCore;
using MinhaApiOracle.Models;

namespace MinhaApiOracle.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options) {}

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<EstacionamentoMoto> EstacionamentoMotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vaga>().HasKey(v => new { v.Numero, v.Id });
        }
    }
}
