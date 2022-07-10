using System.ComponentModel.DataAnnotations;

namespace ViagemAPI.Data.Dto.Veiculo
{
    public class UpdateVeiculoDto
    {
        public int Id { get; set; }
        public string Placa { get; set; }
    }
}
