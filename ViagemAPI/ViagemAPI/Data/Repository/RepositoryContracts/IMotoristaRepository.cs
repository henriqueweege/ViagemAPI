using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface IMotoristaRepository
    {
        IEnumerable<Motorista> BuscarTodosOsMotoristas();
        Motorista BuscarMotoristaPorId(int id);
        bool DeletarMotoristaPorId(int id);
        bool AtualizarMotorista(int id, MotoristaDto veiculoToUpdate);
        bool CriarNovoVeiculo(MotoristaDto veiculoToPost);
    }
}
