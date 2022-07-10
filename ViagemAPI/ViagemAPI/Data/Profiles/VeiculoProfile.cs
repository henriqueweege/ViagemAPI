using AutoMapper;
using ViagemAPI.Data.Dto.Veiculo;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Profiles
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<CreateVeiculoDto, Veiculo>();
            CreateMap<UpdateVeiculoDto, Veiculo>();
            CreateMap<Veiculo, ReadVeiculoDto>();
        }
    }
}
