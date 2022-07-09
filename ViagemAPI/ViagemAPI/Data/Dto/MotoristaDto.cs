using System.ComponentModel.DataAnnotations;

namespace ViagemAPI.Data.Dto
{
    public class MotoristaDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[0-9]).{11}$")]
        public string Cpf { get; set; }
    }
}
