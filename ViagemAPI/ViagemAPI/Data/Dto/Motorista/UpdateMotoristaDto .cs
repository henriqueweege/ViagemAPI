using System.ComponentModel.DataAnnotations;

namespace ViagemAPI.Data.Dto.Motorista
{
    public class UpdateMotoristaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
