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
            get { return placa; }
            set
            {
                var regexPlacaAntiga = new Regex(@"^([A-Z]){3}-(\d){4}$");
                var regexPlacaNova = new Regex(@"^([A-Z]){3}(\d){1}([A-Z]){1}(\d){2}$");
                if (regexPlacaAntiga.IsMatch(value) || regexPlacaNova.IsMatch(value))
                {
                    placa = value;
                    return;
                }
                throw new Exception("Placa em fomato inválido.");
            }
        }
    }
}
