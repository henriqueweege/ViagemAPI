using ViagemAPI.Data.Dto;
using ViagemAPI.ViewModel;


namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface IMotoristaRepository
    {
        MotoristaViewModel CriarNovoMotorista(MotoristaDto motoristaParaCriar);
        IEnumerable<MotoristaViewModel> BuscarTodosOsMotoristas();
        MotoristaViewModel BuscarMotoristaPorId(int id);
        MotoristaViewModel BuscarMotoristaPeloCpf(string cpf);
        MotoristaViewModel AtualizarMotorista(int id, MotoristaDto motoristaParaAtualizar);
        bool DeletarMotoristaPorId(int id);

    }
}
