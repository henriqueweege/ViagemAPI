using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface IViagemRepository
    {
        Viagem CriarNovaViagem(ViagemDto viagemParaCriar);
        IEnumerable<Viagem> BuscarTodasAsViagens();
        Viagem BuscarViagemPorId(int id);
        IEnumerable<Viagem> BuscarViagemPorData(DateTime dataDaViagem);
        Viagem AtualizarViagem(Viagem viagemParaAtualizar);
        bool DeletarViagemPorId(int id);
    }
}
