using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface IVeiculoRepository
    {
        Veiculo CriarNovoVeiculo(Veiculo veiculoParaCriar);
        IEnumerable<Veiculo> BuscarTodosOsVeiculos();
        Veiculo BuscarVeiculoPorId(int id);
        Veiculo BuscarVeiculoPelaPlaca(string placa);
        Veiculo AtualizarVeiculo(Veiculo veiculoParaAtualizar);
        bool DeletarVeiculoPorId(int id);

        bool CheckarSePlacaEstaDiponivel(string placa);
    }
}
