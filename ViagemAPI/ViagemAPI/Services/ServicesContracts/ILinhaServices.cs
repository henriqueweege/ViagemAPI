using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Services.ServicesContracts
{
    public interface ILinhaServices
    {
        public Linha TransformaDtoEmLinha(LinhaDto linhaParaMapear);
        public LinhaViewModel TransformaLinhaEmViewModel(Linha linhaParaMapear);
        public IEnumerable<LinhaViewModel> TransformaLinhasEmViewModelList(IEnumerable<Linha> listaParaConverter);

    }
}
