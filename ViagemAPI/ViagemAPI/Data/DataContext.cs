using Microsoft.EntityFrameworkCore;
using ViagemAPI.Model;

namespace ViagemAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Viagem> Viagem { get; set; }
        public DbSet<Motorista> Motorista { get; set; }
        public DbSet<Linha> Linha { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string stringconexao = "server=localhost;DataBase=viagemDb;Uid=root;Pwd=root";
            optionsBuilder.UseMySql(stringconexao, ServerVersion.AutoDetect(stringconexao));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Placa);
            });

            modelBuilder.Entity<Viagem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdMotorista).IsRequired();
                entity.Property(e => e.IdLinha).IsRequired();
                entity.Property(e => e.DataPartida).IsRequired();
                entity.Property(e => e.DataChegada).IsRequired();
                entity.Property(e => e.NumeroServico).IsRequired();

            });

            modelBuilder.Entity<Motorista>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Cpf).IsRequired();
            });

            modelBuilder.Entity<Linha>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Destino).IsRequired();
                entity.Property(e => e.Origem).IsRequired();
                entity.Property(e => e.Numero).IsRequired();
                entity.Property(e => e.Nome).IsRequired();
            });
        }
    }
}
