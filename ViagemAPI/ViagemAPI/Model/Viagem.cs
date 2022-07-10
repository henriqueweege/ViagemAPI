using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ViagemAPI.Model
{
    public class Viagem
    {
        [Key]
        public int Id { get; set; }

        public string NumeroServico { get; set; }

        [ForeignKey("Linha")]
        public int IdLinha { get; set; }

        [ForeignKey("Motorista")]
        public int IdMotorista { get; set; }

        public DateTime DataPartida { get; set; }

        public DateTime DataChegada { get; set; }
    }
}
