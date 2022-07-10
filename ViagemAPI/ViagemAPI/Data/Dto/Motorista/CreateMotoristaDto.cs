using System.ComponentModel.DataAnnotations;

namespace ViagemAPI.Data.Dto.Motorista
{
    public class CreateMotoristaDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
