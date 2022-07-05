using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository
{
    public class MotoristaRepository : IMotoristaRepository
    {
        public DataContext Context { get; set; }
        public MotoristaRepository(DataContext context)
        {
            Context = context;
        }
        public bool AtualizarMotorista(int id, MotoristaDto veiculoToUpdate)
        {
            throw new NotImplementedException();
        }

        public Motorista BuscarMotoristaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Motorista> BuscarTodosOsMotoristas()
        {
            throw new NotImplementedException();
        }

        public bool CriarNovoVeiculo(MotoristaDto veiculoToPost)
        {
            throw new NotImplementedException();
        }

        public bool DeletarMotoristaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
