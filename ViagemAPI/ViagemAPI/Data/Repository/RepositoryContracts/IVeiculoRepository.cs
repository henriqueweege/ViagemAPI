using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface IVeiculoRepository
    {
        Veiculo CriarNovoVeiculo(VeiculoDto veiculoToPost);
        IEnumerable<Veiculo> BuscarTodosOsVeiculos();
        Veiculo BuscarVeiculoPorId(int id);
        Veiculo BuscarVeiculoPelaPlaca(string placa);
        Veiculo AtualizarVeiculo(Veiculo veiculoToUpdate);
        bool DeletarVeiculoPorId(int id);
    }
}
