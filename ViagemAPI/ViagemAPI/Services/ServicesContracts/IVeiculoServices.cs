using ViagemAPI.Data.Dto.Veiculo;
using ViagemAPI.Model;

namespace ViagemAPI.Services.ServicesContracts
{
    public interface IVeiculoServices
    {
        public Veiculo TransformaCreateDtoEmVeiculo(CreateVeiculoDto veiculoParaMapear);
        public Veiculo TransformaUpdateDtoEmVeiculo(UpdateVeiculoDto veiculoParaMapear);

        public ReadVeiculoDto TransformaVeiculoEmViewModel(Veiculo linhaParaMapear);
        public IEnumerable<ReadVeiculoDto> TransformaVeiculosEmViewModelList(IEnumerable<Veiculo> listaParaConverter);
        public bool CheckarFormatoPlaca(string placaParaCheckar);


    }
}
