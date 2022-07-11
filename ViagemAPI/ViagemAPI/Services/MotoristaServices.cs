using AutoMapper;
using System.Text.RegularExpressions;
using ViagemAPI.Data;
using ViagemAPI.Data.Dto.Motorista;
using ViagemAPI.Model;
using ViagemAPI.Services.ServicesContracts;

namespace ViagemAPI.Services
{
    public class MotoristaServices : IMotoristaServices
    {
        public IMapper Mapper { get; set; }

        public MotoristaServices(IMapper mapper)
        {
            Mapper = mapper;
        }
        public Motorista TransformaCreateDtoEmMotorista(CreateMotoristaDto motoristaParaMapear)
        {
            Motorista motoristaMapeado;
            motoristaMapeado = Mapper.Map<Motorista>(motoristaParaMapear);
            if (motoristaMapeado != null) return motoristaMapeado;
            throw new Exception("Erro no mapeamento");  
        }

        public ReadMotoristaDto TransformaMotoristaEmViewModel(Motorista motoristaParaMapear)
        {
            ReadMotoristaDto motoristaMapeado;
            motoristaMapeado = Mapper.Map<ReadMotoristaDto>(motoristaParaMapear);
            if (motoristaMapeado != null) return motoristaMapeado;
            throw new Exception("Erro no mapeamento");
        }

        public IEnumerable<ReadMotoristaDto> TransformaMotoristasEmViewModelList(IEnumerable<Motorista> listaParaConverter)
        {

            var motoristasRetorno = new List<ReadMotoristaDto>();
            foreach (var motorista in listaParaConverter)
            {
                motoristasRetorno.Add(TransformaMotoristaEmViewModel(motorista));
            }
            if (motoristasRetorno != null) return motoristasRetorno;
            throw new Exception("Erro  no mapeamento");
        }

        public Motorista TransformaUpdateDtoEmMotorista(UpdateMotoristaDto motoristaParaMapear)
        {
            Motorista motoristaMapeado;
            motoristaMapeado = Mapper.Map<Motorista>(motoristaParaMapear);
            if (motoristaMapeado != null) return motoristaMapeado;
            throw new Exception("Erro no mapeamento");
        }

        public bool CheckarFormatoCpf(string cpf)
        {
            var regex = new Regex(@"^(\d{11})$");
            if (regex.IsMatch(cpf))
            {
                return true;
            }
            return false;
        }
    }
}
