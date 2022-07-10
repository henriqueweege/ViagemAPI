using AutoMapper;
using ViagemAPI.Data.Dto.Motorista;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Profiles
{
    sealed class MotoristaProfile : Profile
    {
        public MotoristaProfile()
        {
            CreateMap<CreateMotoristaDto, Motorista>();
            CreateMap<UpdateMotoristaDto, Motorista>();
            CreateMap<Motorista, ReadMotoristaDto>();

        }
    }
}
