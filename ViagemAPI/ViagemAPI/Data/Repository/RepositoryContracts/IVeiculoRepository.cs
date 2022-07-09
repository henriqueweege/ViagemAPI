using ViagemAPI.Data.Dto;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface IVeiculoRepository
    {
        VeiculoViewModel CriarNovoVeiculo(VeiculoDto veiculoParaCriar);
        IEnumerable<VeiculoViewModel> BuscarTodosOsVeiculos();
        VeiculoViewModel BuscarVeiculoPorId(int id);
        VeiculoViewModel BuscarVeiculoPelaPlaca(string placa);
        VeiculoViewModel AtualizarVeiculo(int id, VeiculoDto veiculoParaAtualizar);
        bool DeletarVeiculoPorId(int id);
    }
}
