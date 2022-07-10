using AutoMapper;
using ViagemAPI.Data.Dto.Linha;
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

        public Linha TransformaCreateDtoEmLinha(CreateLinhaDto linhaParaMapear)
        {
            Linha linhaMapeada;
            linhaMapeada = Mapper.Map<Linha>(linhaParaMapear);
            if (linhaMapeada != null) return linhaMapeada;
            throw new Exception("Erro no mapeamento");

        }

        public ReadLinhaDto TransformaLinhaEmViewModel(Linha linhaParaMapear)
        {
            ReadLinhaDto linhaMapeada;
            linhaMapeada = Mapper.Map<ReadLinhaDto>(linhaParaMapear);
            if (linhaMapeada != null) return linhaMapeada;
            throw new Exception("Erro no mapeamento");



        }

        public IEnumerable<ReadLinhaDto> TransformaLinhasEmViewModelList(IEnumerable<Linha> listaParaConverter)
        {

            IList<ReadLinhaDto> linhasRetorno = new List<ReadLinhaDto>();
            foreach (var linha in listaParaConverter)
            {
                linhasRetorno.Add(TransformaLinhaEmViewModel(linha));
            }
            if (linhasRetorno != null) return linhasRetorno.ToList();
            throw new Exception("Erro  no mapeamento");

        }

        public Linha TransformaUpdateDtoEmLinha(UpdateLinhaDto linhaParaMapear)
        {
            Linha linhaMapeada;
            linhaMapeada = Mapper.Map<Linha>(linhaParaMapear);
            if (linhaMapeada != null) return linhaMapeada;
            throw new Exception("Erro no mapeamento");
        }
    }
}
