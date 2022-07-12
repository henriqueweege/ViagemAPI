using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.ViewModel;


namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface IMotoristaRepository
    {
        Motorista CriarNovoMotorista(Motorista motoristaParaCriar);
        IEnumerable<Motorista> BuscarTodosOsMotoristas();
        Motorista BuscarMotoristaPorId(int id);
        Motorista BuscarMotoristaPeloCpf(string cpf);
        Motorista AtualizarMotorista(Motorista motoristaParaAtualizar);
        bool DeletarMotoristaPorId(int id);

        bool CheckarSeCpfEstaDiponivel(string cpf);

    }
}
