using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Services.ServicesContracts
{
    public interface IVeiculoService
    {
        public Veiculo TransformaDtoEmObjeto(VeiculoDto veiculoParaMapear);
    }
}
