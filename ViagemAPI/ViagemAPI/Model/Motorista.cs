using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ViagemAPI.Model
{
    public class Motorista
    {
        [Key]
        public int Id { get; set; }
        
        public string Nome { get; set; }
        
        private string cpf; 
        public string Cpf 
        {
            get { return cpf; }
            set
            {
                var regex = new Regex(@"^(\d{11})$");
                if (regex.IsMatch(value))
                {
                    cpf = value;
                    return;
                }
                throw new Exception("Cpf em fomato inválido.");
            }
        }
    }
}
