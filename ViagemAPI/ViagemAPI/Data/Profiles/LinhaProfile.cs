using AutoMapper;
using ViagemAPI.Data.Dto.Linha;
using ViagemAPI.Model;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Data.Profiles
{
    sealed class LinhaProfile: Profile
    {
        public LinhaProfile()
        {
            CreateMap<CreateLinhaDto, Linha>();
            CreateMap<UpdateLinhaDto, Linha>();
            CreateMap<Linha, ReadLinhaDto>();
        }
    }
}
