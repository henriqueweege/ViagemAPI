using System.ComponentModel.DataAnnotations;

namespace ViagemAPI.Model
{
    public class Viagem
    {
        [Key]
        public int Id { get; set; }
        public string NumeroServico { get; set; }
        public int IdLinha { get; set; }
        public int IdMotorista { get; set; }
        public DateTime DataPartida { get; set; }
        public DateTime DataChegada { get; set; }
    }
}
