using AutoMapper;
using ViagemAPI.Data;
using ViagemAPI.Data.Dto;
using ViagemAPI.Model;
using ViagemAPI.Services.ServicesContracts;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Services
{
    public class MotoristaServices : IMotoristaServices
    {
        public IMapper Mapper { get; set; }

        public MotoristaServices(IMapper mapper)
        {
            Mapper = mapper;
        }
        public Motorista TransformaDtoEmMotorista(MotoristaDto motoristaParaMapear)
        {
            Motorista motoristaMapeado;
            motoristaMapeado = Mapper.Map<Motorista>(motoristaParaMapear);
            if (motoristaMapeado != null) return motoristaMapeado;
            throw new Exception("Erro no mapeamento");  
        }

        public MotoristaViewModel TransformaMotoristaEmViewModel(Motorista motoristaParaMapear)
        {
            MotoristaViewModel motoristaMapeado;
            motoristaMapeado = Mapper.Map<MotoristaViewModel>(motoristaParaMapear);
            if (motoristaMapeado != null) return motoristaMapeado;
            throw new Exception("Erro no mapeamento");
        }

        public IEnumerable<MotoristaViewModel> TransformaMotoristasEmViewModelList(IEnumerable<Motorista> listaParaConverter)
        {

            var motoristasRetorno = new List<MotoristaViewModel>();
            foreach (var motorista in listaParaConverter)
            {
                motoristasRetorno.Add(TransformaMotoristaEmViewModel(motorista));
            }
            if (motoristasRetorno != null) return motoristasRetorno;
            throw new Exception("Erro  no mapeamento");
        }
    }
}
