using AutoMapper;
using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.Services.ServicesContracts;

namespace ViagemAPI.Services
{
    public class MotoristaServices : IMotoristaServices
    {
        public IMapper Mapper { get; set; }

        public MotoristaServices(IMapper mapper)
        {
            Mapper = mapper;
        }
        public Motorista TransformaDtoEmObjeto(MotoristaDto motoristaParaMapear)
        {
            Motorista motoristaMapeado;
            try
            {
                motoristaMapeado = Mapper.Map<Motorista>(motoristaParaMapear);
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
