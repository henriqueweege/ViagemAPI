using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Services.ServicesContracts
{
    public interface IMotoristaServices
    {
        public Motorista TransformaDtoEmMotorista(MotoristaDto dto);
        public MotoristaViewModel TransformaMotoristaEmViewModel(Motorista motoristaParaMapear);
        public IEnumerable<MotoristaViewModel> TransformaMotoristasEmViewModelList(IEnumerable<Motorista> listaParaConverter);
        


    }
}
