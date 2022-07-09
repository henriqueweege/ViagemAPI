using AutoMapper;
using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Data.Profiles
{
    sealed class MotoristaProfile : Profile
    {
        public MotoristaProfile()
        {
            CreateMap<MotoristaDto, Motorista>();
            CreateMap<Motorista, MotoristaViewModel>();

        }
    }
}
