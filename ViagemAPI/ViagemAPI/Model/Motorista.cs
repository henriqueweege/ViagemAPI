using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
