using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface IVeiculoRepository
    {
        IEnumerable<Veiculo> BuscarTodosOsVeiculos();
        Veiculo BuscarVeiculoPorId(int id);
        bool DeletarVeiculoPorId(int id);
        bool AtualizarVeiculo(int id, VeiculoDto veiculoToUpdate);
        bool AdicionarNovoVeiculo(VeiculoDto veiculoToPost);
    }
}
