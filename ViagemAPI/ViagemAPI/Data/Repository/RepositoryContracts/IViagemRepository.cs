using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Dto.Viagem;
using ViagemAPI.Model;


namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface IViagemRepository
    {
        ReadViagemDto CriarNovaViagem(Viagem viagemParaCriar);
        IEnumerable<ReadViagemDto> BuscarTodasAsViagens();
        ReadViagemDto BuscarViagemPorId(int id);
        IEnumerable<ReadViagemDto> BuscarViagemPorData(DateTime dataDaViagem);
        ReadViagemDto AtualizarViagem(Viagem viagemParaAtualizar);
        bool DeletarViagemPorId(int id);
        public bool CheckarMesmoNumero(string numeroParaCheckar, DateTime dataPartida);

    }
}
