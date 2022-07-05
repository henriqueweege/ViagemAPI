using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository.Contracts
{
    public interface ILinhaRepository
    {
        IEnumerable<Linha> BuscarTodasAsLinhas();
        Linha BuscarLinhaPorId(int id);
        bool DeletarLinhaPorId(int id);
        Linha AtualizarLinha(int id, LinhaDto veiculoToUpdate);
        Linha CriarNovaLinha(LinhaDto veiculoToPost);
    }
}
