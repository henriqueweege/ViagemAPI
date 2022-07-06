using AutoMapper;
using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.Services.ServicesContracts;

namespace ViagemAPI.Services
{
    public class LinhaServices : ILinhaServices
    {
        public IMapper Mapper { get; set; }
        public LinhaServices(IMapper mapper)
        {
            Mapper = mapper;
        }

        public Linha TransformaDtoEmObjeto(LinhaDto linhaDto)
        {
            Linha linhaMapeada;
            try
            {
                linhaMapeada = Mapper.Map<Linha>(linhaDto);
            }
            catch(Exception exception)
            {
                throw exception;
            }
            if (linhaMapeada != null) return linhaMapeada;

            throw new Exception("Erro no mapeamento");
        }
    }
}
