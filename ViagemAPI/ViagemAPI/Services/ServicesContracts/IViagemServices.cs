using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Services.ServicesContracts
{
    public interface IViagemServices
    {
        public Viagem TransformaDtoEmObjeto(ViagemDto viagemParaMapear);
    }
}
