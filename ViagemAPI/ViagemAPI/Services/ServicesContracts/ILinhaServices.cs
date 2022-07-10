using ViagemAPI.Data.Dto.Linha;
using ViagemAPI.Model;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Services.ServicesContracts
{
    public interface ILinhaServices
    {
        public Linha TransformaCreateDtoEmLinha(CreateLinhaDto linhaParaMapear);
        public Linha TransformaUpdateDtoEmLinha(UpdateLinhaDto linhaParaMapear);
        public ReadLinhaDto TransformaLinhaEmViewModel(Linha linhaParaMapear);
        public IEnumerable<ReadLinhaDto> TransformaLinhasEmViewModelList(IEnumerable<Linha> listaParaConverter);

    }
}
