using System.ComponentModel.DataAnnotations;

namespace ViagemAPI.Data.Dto
{
    public class ViagemDto
    {
        [Required]
        public string NumeroServico { get; set; }
        [Required]
        public int IdLinha { get; set; }
        public int? IdMotorista { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public DateTime DataPartida { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public DateTime DataChegada { get; set; }
    }
}
