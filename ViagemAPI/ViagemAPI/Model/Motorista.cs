using System.ComponentModel.DataAnnotations;

namespace ViagemAPI.Model
{
    public class Motorista
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
