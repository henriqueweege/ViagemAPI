using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository.Contracts
{
    public interface IVeiculoRepository
    {
        IEnumerable<Veiculo> BuscarTodosOsVeiculos();
        Veiculo BuscarVeiculoPorId(int id);
        bool DeletarVeiculoPorId(int id);
        Veiculo AtualizarVeiculo(int id, VeiculoDto veiculoToUpdate);
        Veiculo AdicionarNovoVeiculo(VeiculoDto veiculoToPost);
    }
}
