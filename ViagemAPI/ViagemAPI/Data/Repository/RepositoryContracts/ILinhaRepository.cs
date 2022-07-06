using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface ILinhaRepository
    {
        IEnumerable<Linha> BuscarTodasAsLinhas();
        Linha BuscarLinhaPorId(int id);
        bool DeletarLinhaPorId(int id);
        Linha AtualizarLinha(Linha linhaParaAtualizar);
        Linha CriarNovaLinha(LinhaDto linhaParaCriar);
        Linha BuscarLinhaPeloNumero(int numero);
    }
}
