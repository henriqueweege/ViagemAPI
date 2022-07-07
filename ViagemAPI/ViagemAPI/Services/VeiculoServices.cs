using AutoMapper;
using ViagemAPI.Data.Dto;
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
        public Veiculo TransformaDtoEmObjeto(VeiculoDto veiculoParaMapear)
        {
            Veiculo motoristaMapeado;
            try
            {
                motoristaMapeado = Mapper.Map<Veiculo>(veiculoParaMapear);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            if (motoristaMapeado != null) return motoristaMapeado;

            throw new Exception("Erro no mapeamento");
        }
    }
}
