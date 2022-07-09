using AutoMapper;
using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Data.Profiles
{
    public class ViagemProfile : Profile
    {
        public ViagemProfile()
        {
            CreateMap<ViagemDto, Viagem>();
            CreateMap<Viagem, ViagemViewModel>();

        }
    }
}
