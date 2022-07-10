using AutoMapper;
using ViagemAPI.Data.Dto.Viagem;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Profiles
{
    public class ViagemProfile : Profile
    {
        public ViagemProfile()
        {
            CreateMap<CreateViagemDto, Viagem>();
            CreateMap<UpdateViagemDto, Viagem>();
            CreateMap<Viagem, ReadViagemDto>();

        }
    }
}
