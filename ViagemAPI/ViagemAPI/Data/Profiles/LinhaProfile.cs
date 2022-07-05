using AutoMapper;
using ViagemAPI.Data.Dto;
using ViagemAPI.Model;

namespace ViagemAPI.Data.Profiles
{
    sealed class LinhaProfile: Profile
    {
        public LinhaProfile()
        {
            CreateMap<LinhaDto, Linha>();
            CreateMap<Linha, LinhaDto > ();

        }
    }
}
