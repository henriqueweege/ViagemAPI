using AutoMapper;
using ViagemAPI.Data.Dto.Viagem;
using ViagemAPI.Model;
using ViagemAPI.Services.ServicesContracts;

namespace ViagemAPI.Services
{
    public class ViagemServices : IViagemServices
    {
        public IMapper Mapper { get; set; }
        public ViagemServices(IMapper mapper)
        {
            Mapper = mapper;
        }


            
        public Viagem TransformaCreateDtoEmViagem(CreateViagemDto viagemParaMapear)
        {
            Viagem viagemMapeada;
            viagemMapeada = Mapper.Map<Viagem>(viagemParaMapear);

            if (viagemMapeada != null) return viagemMapeada;
            throw new Exception("Erro no mapeamento");
        }

        public ReadViagemDto TransformaViagemEmViewModel(Viagem viagemParaMapear, Linha linha, Motorista? motorista)
        {
            ReadViagemDto viagemMapeada;
            viagemMapeada = Mapper.Map<ReadViagemDto>(viagemParaMapear);
            viagemMapeada.NumeroLinha = linha.Numero;
            viagemMapeada.Origem = linha.Origem;
            viagemMapeada.Destino = linha.Destino;

            if (motorista == null) viagemMapeada.NomeMotorista = null;
            else viagemMapeada.NomeMotorista = motorista.Nome;

            if (viagemMapeada != null) return viagemMapeada;
            throw new Exception("Erro no mapeamento");
        }

        public Viagem TransformaUpdateDtoEmViagem(UpdateViagemDto viagemParaMapear)
        {
            Viagem viagemMapeada;
            viagemMapeada = Mapper.Map<Viagem>(viagemParaMapear);

            if (viagemMapeada != null) return viagemMapeada;
            throw new Exception("Erro no mapeamento");
        }
    }
}
