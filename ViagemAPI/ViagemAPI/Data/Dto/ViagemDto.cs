namespace ViagemAPI.Data.Dto
{
    public class ViagemDto
    {
        public string NumeroServico { get; set; }
        public int IdLinha { get; set; }
        public int IdMotorista { get; set; }
        public DateTime DataPartida { get; set; }
        public DateTime DataChegada { get; set; }
    }
}
