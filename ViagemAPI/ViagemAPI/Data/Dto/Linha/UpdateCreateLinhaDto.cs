using System.ComponentModel.DataAnnotations;

namespace ViagemAPI.Data.Dto.Linha
{
    public class UpdateLinhaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
    }
}
