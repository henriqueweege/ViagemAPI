using AutoMapper;
using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Data.Profiles
{
    sealed class LinhaProfile: Profile
    {
        public LinhaProfile()
        {
            CreateMap<LinhaDto, Linha>();
            CreateMap<Linha, LinhaViewModel>();
        }
    }
}
