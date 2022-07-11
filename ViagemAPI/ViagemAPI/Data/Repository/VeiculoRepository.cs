using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;
using ViagemAPI.Services;
using ViagemAPI.Services.ServicesContracts;
using ViagemAPI.ViewModel;


namespace ViagemAPI.Data.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        public DataContext Context { get; set; }
        public VeiculoRepository(DataContext context)
        {
            Context = context;
        }

        public Veiculo CriarNovoVeiculo(Veiculo veiculoParaCriar)
        {
            Context.Add(veiculoParaCriar);

            if (Context.SaveChanges() > 0) return Context.Veiculo.OrderBy(v => v.Id)
                                                                 .LastOrDefault(v => v.Placa == veiculoParaCriar.Placa);
            return null;

        }

        public IEnumerable<Veiculo> BuscarTodosOsVeiculos()
        {

            var veiculosExistentes = Context.Veiculo;
            if (veiculosExistentes.ToList().Count > 0) return veiculosExistentes;
            return null;
        }

        public Veiculo BuscarVeiculoPorId(int id)
        {
            var veiculoPesquisado = Context.Veiculo.FirstOrDefault(v => v.Id == id);

            if(veiculoPesquisado != null) return veiculoPesquisado;
            return null;
        }

        public Veiculo BuscarVeiculoPelaPlaca(string placa)
        {

            var veiculo = Context.Veiculo.FirstOrDefault(v => v.Placa == placa);
            if (veiculo != null) return veiculo;
            return null;


        }

        public Veiculo AtualizarVeiculo(Veiculo veiculoParaAtualizar)
        {
                     
            Context.Veiculo.Update(veiculoParaAtualizar);
            if (Context.SaveChanges() > 0) return veiculoParaAtualizar;
            return null;
        }

        public bool DeletarVeiculoPorId(int id)
        {

            var veiculoParaDeletar = Context.Veiculo.FirstOrDefault(v => v.Id == id);
            if (veiculoParaDeletar != null) Context.Veiculo.Remove(veiculoParaDeletar);
            else 
            {
                return false;
            }

            if (Context.SaveChanges() > 0) return true;
            return false;
        }

    }
}
