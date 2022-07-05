using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.Contracts;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        public DataContext Context { get; set; }
        public VeiculoRepository(DataContext context)
        {
            Context = context;
        }
        public Veiculo AdicionarNovoVeiculo(VeiculoDto veiculoToPost)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Veiculo> BuscarTodosOsVeiculos()
        {
            throw new NotImplementedException();
        }

        public Veiculo BuscarVeiculoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeletarVeiculoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Veiculo AtualizarVeiculo(int id, VeiculoDto veiculoToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
