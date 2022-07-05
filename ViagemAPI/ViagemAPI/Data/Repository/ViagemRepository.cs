using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository
{
    public class ViagemRepository : IViagemRepository
    {
        public DataContext Context { get; set; }
        public ViagemRepository(DataContext context)
        {
            Context = context;
        }
        public bool AtualizarViagem(int id, ViagemDto veiculoToUpdate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Viagem> BuscarTodasAsViagens()
        {
            throw new NotImplementedException();
        }

        public Viagem BuscarViagemPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool CriarNovoVeiculo(ViagemDto veiculoToPost)
        {
            throw new NotImplementedException();
        }

        public bool DeletarViagemPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
