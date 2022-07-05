using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.Contracts;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Repository
{
    public class ViagemRepository : IViagemRepository
    {
        public Viagem AtualizarViagem(int id, ViagemDto veiculoToUpdate)
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

        public Viagem CriarNovoVeiculo(ViagemDto veiculoToPost)
        {
            throw new NotImplementedException();
        }

        public bool DeletarViagemPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
