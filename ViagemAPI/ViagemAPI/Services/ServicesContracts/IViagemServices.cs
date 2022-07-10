using ViagemAPI.Data.Dto.Viagem;
using ViagemAPI.Model;

namespace ViagemAPI.Services.ServicesContracts
{
    public interface IViagemServices
    {
        public Viagem TransformaCreateDtoEmViagem(CreateViagemDto viagemParaMapear);
        public Viagem TransformaUpdateDtoEmViagem(UpdateViagemDto viagemParaMapear);

        public ReadViagemDto TransformaViagemEmViewModel(Viagem linhaParaMapear, Linha linha, Motorista motorista);

    }
}
