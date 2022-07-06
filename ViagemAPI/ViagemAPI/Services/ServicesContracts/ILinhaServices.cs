using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Services.ServicesContracts
{
    public interface ILinhaServices
    {
        public Linha TransformaDtoEmObjeto(LinhaDto linhaDto);
    }
}
