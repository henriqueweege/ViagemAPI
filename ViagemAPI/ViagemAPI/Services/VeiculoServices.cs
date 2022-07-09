using AutoMapper;
using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.Services.ServicesContracts;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Services
{
    public class VeiculoServices : IVeiculoServices
    {
        public IMapper Mapper { get; set; }

        public VeiculoServices(IMapper mapper)
        {
            Mapper = mapper;
        }
        public Veiculo TransformaDtoEmVeiculo(VeiculoDto veiculoParaMapear)
        {
            Veiculo veiculoMapeado;
            try
            {
                veiculoMapeado = Mapper.Map<Veiculo>(veiculoParaMapear);
                if (veiculoMapeado != null) return veiculoMapeado;
                throw new Exception("Erro no mapeamento");
            }
            catch (Exception exception)
            {
                throw exception;
            }
           
        }

        public VeiculoViewModel TransformaVeiculoEmViewModel(Veiculo veiculoParaMapear)
        {
            VeiculoViewModel veiculoMapeado;
            try
            {
                veiculoMapeado = Mapper.Map<VeiculoViewModel>(veiculoParaMapear);
                if (veiculoMapeado != null) return veiculoMapeado;
                throw new Exception("Erro no mapeamento");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
        }

        public IEnumerable<VeiculoViewModel> TransformaVeiculosEmViewModelList(IEnumerable<Veiculo> listaParaConverter)
        {
            try
            {
                var veiculosRetorno = new List<VeiculoViewModel>();
                foreach (var veiculo in listaParaConverter)
                {
                    veiculosRetorno.Add(TransformaVeiculoEmViewModel(veiculo));
                }
                if (veiculosRetorno != null) return veiculosRetorno;
                throw new Exception("Erro na conversão");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
