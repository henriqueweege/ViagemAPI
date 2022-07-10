using AutoMapper;
using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.Services.ServicesContracts;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Services
{
    public class LinhaServices : ILinhaServices
    {
        public IMapper Mapper { get; set; }
        public LinhaServices(IMapper mapper)
        {
            Mapper = mapper;
        }

        public Linha TransformaDtoEmLinha(LinhaDto linhaParaMapear)
        {
            Linha linhaMapeada;
            linhaMapeada = Mapper.Map<Linha>(linhaParaMapear);
            if (linhaMapeada != null) return linhaMapeada;
            throw new Exception("Erro no mapeamento");

        }

        public LinhaViewModel TransformaLinhaEmViewModel(Linha linhaParaMapear)
        {
            LinhaViewModel linhaMapeada;
            linhaMapeada = Mapper.Map<LinhaViewModel>(linhaParaMapear);
            if (linhaMapeada != null) return linhaMapeada;
            throw new Exception("Erro no mapeamento");



        }

        public IEnumerable<LinhaViewModel> TransformaLinhasEmViewModelList(IEnumerable<Linha> listaParaConverter)
        {

            IList<LinhaViewModel> linhasRetorno = new List<LinhaViewModel>();
            foreach (var linha in listaParaConverter)
            {
                linhasRetorno.Add(TransformaLinhaEmViewModel(linha));
            }
            if (linhasRetorno != null) return linhasRetorno.ToList();
            throw new Exception("Erro  no mapeamento");

        }
    }
}
