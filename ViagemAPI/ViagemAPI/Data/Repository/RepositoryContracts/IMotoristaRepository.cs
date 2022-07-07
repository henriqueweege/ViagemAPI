using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface IMotoristaRepository
    {
        Motorista CriarNovoMotorista(MotoristaDto motoristaParaCriar);
        IEnumerable<Motorista> BuscarTodosOsMotoristas();
        Motorista BuscarMotoristaPorId(int id);
        Motorista BuscarMotoristaPeloCpf(string cpf);
        bool DeletarMotoristaPorId(int id);
        Motorista AtualizarMotorista(Motorista motoristaParaAtualizar);
    }
}
