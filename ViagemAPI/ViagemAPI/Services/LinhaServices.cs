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
            try
            {
                linhaMapeada = Mapper.Map<Linha>(linhaParaMapear);
                if (linhaMapeada != null) return linhaMapeada;
                throw new Exception("Erro no mapeamento");
            }
            catch(Exception exception)
            {
                throw exception;
            }

        }

        public LinhaViewModel TransformaLinhaEmViewModel(Linha linhaParaMapear)
        {
            LinhaViewModel linhaMapeada;
            try
            {
                linhaMapeada = Mapper.Map<LinhaViewModel>(linhaParaMapear);
                if (linhaMapeada != null) return linhaMapeada;
                throw new Exception("Erro no mapeamento");
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public IEnumerable<LinhaViewModel> TransformaLinhasEmViewModelList(IEnumerable<Linha> listaParaConverter)
        {
            try
            {
                IList<LinhaViewModel> linhasRetorno = new List<LinhaViewModel>();
                foreach (var linha in listaParaConverter)
                {
                    linhasRetorno.Add(TransformaLinhaEmViewModel(linha));
                }
                if (linhasRetorno != null) return linhasRetorno.ToList();
                throw new Exception("Erro na conversão");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
