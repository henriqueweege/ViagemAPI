using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository
{
    public class LinhaRepository : ILinhaRepository
    {
        public DataContext Context { get; set; }
        public LinhaRepository(DataContext context)
        {
            Context = context;
        }
        public bool AtualizarLinha(int id, LinhaDto veiculoToUpdate)
        {
            Context.Update(veiculoToUpdate);
            if (Context.SaveChanges() > 0) return true;
            return false;
        }

        public Linha BuscarLinhaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Linha> BuscarTodasAsLinhas()
        {
            throw new NotImplementedException();
        }

        public bool CriarNovaLinha(LinhaDto veiculoToPost)
        {
            throw new NotImplementedException();
        }

        public bool DeletarLinhaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
