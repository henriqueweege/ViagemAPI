using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Services.ServicesContracts
{
    public interface IVeiculoServices
    {
        public Veiculo TransformaDtoEmObjeto(VeiculoDto veiculoParaMapear);
    }
}
