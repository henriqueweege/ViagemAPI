using ViagemAPI.Model;

namespace ViagemAPI.ViewModel
{
    public class ViagemViewModel
    {
        public int Id { get; set; }
        public string NumeroServico { get; set; }
        public int NumeroLinha { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string? NomeMotorista { get; set; }
        public DateTime DataPartida { get; set; }
        public DateTime DataChegada { get; set; }
    }
}
