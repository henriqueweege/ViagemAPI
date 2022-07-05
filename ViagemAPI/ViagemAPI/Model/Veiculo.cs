using System.ComponentModel.DataAnnotations;

namespace ViagemAPI.Model
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }
        public string Placa { get; set; }
    }
}
