using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Services.ServicesContracts
{
    public interface IVeiculoServices
    {
        public Veiculo TransformaDtoEmVeiculo(VeiculoDto veiculoParaMapear);
        public VeiculoViewModel TransformaVeiculoEmViewModel(Veiculo linhaParaMapear);
        public IEnumerable<VeiculoViewModel> TransformaVeiculosEmViewModelList(IEnumerable<Veiculo> listaParaConverter);


    }
}
