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

    }
}
