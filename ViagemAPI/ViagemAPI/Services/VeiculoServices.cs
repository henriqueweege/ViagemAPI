using AutoMapper;
using ViagemAPI.Data.Dto.Veiculo;
using ViagemAPI.Model;
using ViagemAPI.Services.ServicesContracts;

namespace ViagemAPI.Services
{
    public class VeiculoServices : IVeiculoServices
    {
        public IMapper Mapper { get; set; }

        public VeiculoServices(IMapper mapper)
        {
            Mapper = mapper;
        }
        public Veiculo TransformaCreateDtoEmVeiculo(CreateVeiculoDto veiculoParaMapear)
        {
            Veiculo veiculoMapeado;
            veiculoMapeado = Mapper.Map<Veiculo>(veiculoParaMapear);
            if (veiculoMapeado != null) return veiculoMapeado;
            throw new Exception("Erro no mapeamento");
           
        }

        public ReadVeiculoDto TransformaVeiculoEmViewModel(Veiculo veiculoParaMapear)
        {
            ReadVeiculoDto veiculoMapeado;
            veiculoMapeado = Mapper.Map<ReadVeiculoDto>(veiculoParaMapear);
            if (veiculoMapeado != null) return veiculoMapeado;
            throw new Exception("Erro no mapeamento");
        }

        public IEnumerable<ReadVeiculoDto> TransformaVeiculosEmViewModelList(IEnumerable<Veiculo> listaParaConverter)
        {
            var veiculosRetorno = new List<ReadVeiculoDto>();
            foreach (var veiculo in listaParaConverter)
            {
                veiculosRetorno.Add(TransformaVeiculoEmViewModel(veiculo));
            }
            if (veiculosRetorno != null) return veiculosRetorno;
            throw new Exception("Erro  no mapeamento");
        }

        public Veiculo TransformaUpdateDtoEmVeiculo(UpdateVeiculoDto veiculoParaMapear)
        {
            Veiculo veiculoMapeado;
            veiculoMapeado = Mapper.Map<Veiculo>(veiculoParaMapear);
            if (veiculoMapeado != null) return veiculoMapeado;
            throw new Exception("Erro no mapeamento");
        }
    }
}
