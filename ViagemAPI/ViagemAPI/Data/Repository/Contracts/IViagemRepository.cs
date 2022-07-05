using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository.Contracts
{
    public interface IViagemRepository
    {
        IEnumerable<Viagem> BuscarTodasAsViagens();
        Viagem BuscarViagemPorId(int id);
        bool DeletarViagemPorId(int id);
        Viagem AtualizarViagem(int id, ViagemDto veiculoToUpdate);
        Viagem CriarNovoVeiculo(ViagemDto veiculoToPost);
    }
}
