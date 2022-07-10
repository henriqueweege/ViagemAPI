using AutoMapper;
using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.Services.ServicesContracts;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Services
{
    public class ViagemServices : IViagemServices
    {
        public IMapper Mapper { get; set; }
        public ViagemServices(IMapper mapper)
        {
            Mapper = mapper;
        }


            
        public Viagem TransformaDtoEmViagem(ViagemDto viagemParaMapear)
        {
            Viagem viagemMapeada;
            viagemMapeada = Mapper.Map<Viagem>(viagemParaMapear);

            if (viagemMapeada != null) return viagemMapeada;
            throw new Exception("Erro no mapeamento");
        }

        public ViagemViewModel TransformaViagemEmViewModel(Viagem viagemParaMapear, Linha linha, Motorista? motorista)
        {
            ViagemViewModel viagemMapeada;
            viagemMapeada = Mapper.Map<ViagemViewModel>(viagemParaMapear);
            viagemMapeada.NumeroLinha = linha.Numero;
            viagemMapeada.Origem = linha.Origem;
            viagemMapeada.Destino = linha.Destino;

            if (motorista == null) viagemMapeada.NomeMotorista = null;
            else viagemMapeada.NomeMotorista = motorista.Nome;

            if (viagemMapeada != null) return viagemMapeada;
            throw new Exception("Erro no mapeamento");
        }
    }
}
