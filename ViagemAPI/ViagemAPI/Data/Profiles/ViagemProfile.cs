using AutoMapper;
using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Profiles
{
    public class ViagemProfile : Profile
    {
        public ViagemProfile()
        {
            CreateMap<ViagemDto, Viagem>();
            CreateMap<Viagem, ViagemDto>();

        }
    }
}
