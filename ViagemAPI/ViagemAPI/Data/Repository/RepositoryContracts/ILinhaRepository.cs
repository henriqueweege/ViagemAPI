using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface ILinhaRepository
    {
        Linha CriarNovaLinha(Linha linhaParaCriar);
        IEnumerable<Linha> BuscarTodasAsLinhas();
        Linha BuscarLinhaPorId(int id);
        Linha BuscarLinhaPeloNumero(int numero);
        Linha AtualizarLinha(Linha linhaParaAtualizar);
        bool DeletarLinhaPorId(int id);
    }
}
