using System.ComponentModel.DataAnnotations;

namespace ViagemAPI.Data.Dto
{
    public class VeiculoDto
    {
        [Required]
        [RegularExpression(@"^([A-Z]){3}-(\d){4}|([A-Z]){3}(\d){1}([A-Z]){1}(\d){2}$")]

        public string Placa { get; set; }
    }
}
