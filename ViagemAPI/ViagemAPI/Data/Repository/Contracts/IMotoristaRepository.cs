using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository.Contracts
{
    public interface IMotoristaRepository
    {
        IEnumerable<Motorista> BuscarTodosOsMotoristas();
        Motorista BuscarMotoristaPorId(int id);
        bool DeletarMotoristaPorId(int id);
        Motorista AtualizarMotorista(int id, MotoristaDto veiculoToUpdate);
        Motorista CriarNovoVeiculo(MotoristaDto veiculoToPost);
    }
}
