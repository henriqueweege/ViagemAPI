using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ViagemAPI.Model
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        private string placa;
        public string Placa
        {
            get { return Placa; }
            set
            {
                var regex = new Regex(@"^([A-Z]){3}-(\d){4}|([A-Z]){3}(\d){1}([A-Z]){1}(\d){2}$");
                if (regex.IsMatch(value))
                {
                    Placa = value;
                    return;
                }
                throw new Exception("Placa em fomato inválido.");
            }
        }
    }
}
