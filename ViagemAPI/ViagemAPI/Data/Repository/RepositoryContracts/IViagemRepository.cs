using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface IViagemRepository
    {
        IEnumerable<Viagem> BuscarTodasAsViagens();
        Viagem BuscarViagemPorId(int id);
        bool DeletarViagemPorId(int id);
        bool AtualizarViagem(int id, ViagemDto veiculoToUpdate);
        bool CriarNovoVeiculo(ViagemDto veiculoToPost);
    }
}
