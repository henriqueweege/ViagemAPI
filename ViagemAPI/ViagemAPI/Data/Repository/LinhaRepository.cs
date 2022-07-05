using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.Contracts;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository
{
    public class LinhaRepository : ILinhaRepository
    {
        public Linha AtualizarLinha(int id, LinhaDto veiculoToUpdate)
        {
            throw new NotImplementedException();
        }

        public Linha BuscarLinhaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Linha> BuscarTodasAsLinhas()
        {
            throw new NotImplementedException();
        }

        public Linha CriarNovaLinha(LinhaDto veiculoToPost)
        {
            throw new NotImplementedException();
        }

        public bool DeletarLinhaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
