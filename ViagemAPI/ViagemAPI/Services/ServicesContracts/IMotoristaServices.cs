using ViagemAPI.Data.Dto.Motorista;
using ViagemAPI.Model;

namespace ViagemAPI.Services.ServicesContracts
{
    public interface IMotoristaServices
    {
        public Motorista TransformaCreateDtoEmMotorista(CreateMotoristaDto motoristaParaMapear);
        public Motorista TransformaUpdateDtoEmMotorista(UpdateMotoristaDto motoristaParaMapear);
        public ReadMotoristaDto TransformaMotoristaEmViewModel(Motorista motoristaParaMapear);
        public IEnumerable<ReadMotoristaDto> TransformaMotoristasEmViewModelList(IEnumerable<Motorista> listaParaConverter);
        public bool CheckarFormatoCpf(string cpf);




    }
}
