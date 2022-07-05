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
        public Linha TransformaDtoEmObjeto(LinhaDto dto)
        {
            try
            {
                Linha linha = Mapper.Map<Linha>(dto);
                if (linha != null) return linha;
                throw new Exception("Erro no mapeamento");

            }
            catch(Exception exception)
            {
                throw exception;
            }
            
        }
    }
}
