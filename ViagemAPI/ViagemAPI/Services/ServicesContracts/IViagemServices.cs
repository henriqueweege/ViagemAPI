using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Services.ServicesContracts
{
    public interface IViagemServices
    {
        public Viagem TransformaDtoEmViagem(ViagemDto viagemParaMapear);
        public ViagemViewModel TransformaViagemEmViewModel(Viagem linhaParaMapear, Linha linha, Motorista motorista);

    }
}
