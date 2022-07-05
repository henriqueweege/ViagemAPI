using AutoMapper;
using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Profiles
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<VeiculoDto, Veiculo>();
            CreateMap<Veiculo, VeiculoDto>();
        }
    }
}
