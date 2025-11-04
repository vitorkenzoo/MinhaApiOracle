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
            // A linha problemática que definia uma chave composta para "Vaga"
            // foi REMOVIDA daqui.
            
            // modelBuilder.Entity<Vaga>().HasKey(v => new { v.Numero, v.Id }); // REMOVIDO

            // O Entity Framework agora vai ler o [Key] do ficheiro Vaga.cs
        }
    }
}
