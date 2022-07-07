using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Services.ServicesContracts
{
    public interface IMotoristaServices
    {
        public Motorista TransformaDtoEmObjeto(MotoristaDto dto);
    }
}
