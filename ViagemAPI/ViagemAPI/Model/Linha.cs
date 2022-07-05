using System.ComponentModel.DataAnnotations;

namespace ViagemAPI.Model
{
    public class Linha
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
    }
}
