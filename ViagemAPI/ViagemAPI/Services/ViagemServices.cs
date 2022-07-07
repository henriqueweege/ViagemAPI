using AutoMapper;
using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.Services.ServicesContracts;

namespace ViagemAPI.Services
{
    public class ViagemServices : IViagemServices
    {
        public IMapper Mapper { get; set; }
        public ViagemServices(IMapper mapper)
        {
            Mapper = mapper;
        }


            
        public Viagem TransformaDtoEmObjeto(ViagemDto viagemParaMapear)
        {
            Viagem viagemMapeada;
            try
            {
                viagemMapeada = Mapper.Map<Viagem>(viagemParaMapear);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            if (viagemMapeada != null) return viagemMapeada;

            throw new Exception("Erro no mapeamento");
        }
    }
}
