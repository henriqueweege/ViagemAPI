using ViagemAPI.Data.Dto;
using ViagemAPI.ViewModel;


namespace ViagemAPI.Data.Repository.RepositoryContracts
{
    public interface IViagemRepository
    {
        ViagemViewModel CriarNovaViagem(ViagemDto viagemParaCriar);
        IEnumerable<ViagemViewModel> BuscarTodasAsViagens();
        ViagemViewModel BuscarViagemPorId(int id);
        IEnumerable<ViagemViewModel> BuscarViagemPorData(DateTime dataDaViagem);
        ViagemViewModel AtualizarViagem(int id, ViagemDto viagemParaAtualizar);
        bool DeletarViagemPorId(int id);
        public bool CheckarMesmoNumero(string numeroParaCheckar, DateTime dataPartida);

    }
}
