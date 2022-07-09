using ViagemAPI.Data.Dto;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface ILinhaRepository
    {
        LinhaViewModel CriarNovaLinha(LinhaDto linhaParaCriar);
        IEnumerable<LinhaViewModel> BuscarTodasAsLinhas();
        LinhaViewModel BuscarLinhaPorId(int id);
        LinhaViewModel BuscarLinhaPeloNumero(int numero);
        LinhaViewModel AtualizarLinha(int id, LinhaDto linhaParaAtualizar);
        bool DeletarLinhaPorId(int id);
    }
}
