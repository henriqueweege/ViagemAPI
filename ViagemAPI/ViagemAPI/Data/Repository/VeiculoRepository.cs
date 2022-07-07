using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;
using ViagemAPI.Services;
using ViagemAPI.Services.ServicesContracts;

namespace ViagemAPI.Data.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        public DataContext Context { get; set; }
        public IVeiculoServices Services { get; set; }
        public VeiculoRepository(DataContext context, VeiculoServices services)
        {
            Context = context;
            Services = services;
        }

        public Veiculo CriarNovoVeiculo(VeiculoDto veiculoParaCriar)
        {
            try
            {
                var veiculoMapeado = Services.TransformaDtoEmObjeto(veiculoParaCriar);
                Context.Add(veiculoMapeado);
                if (Context.SaveChanges() > 0) return Context.Veiculo.OrderBy(v => v.Id).LastOrDefault(v => v.Placa == veiculoParaCriar.Placa);
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IEnumerable<Veiculo> BuscarTodosOsVeiculos()
        {
            try
            {
                IEnumerable<Veiculo> veiculosExistentes = Context.Veiculo;
                if (veiculosExistentes != null) return veiculosExistentes;
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Veiculo BuscarVeiculoPorId(int id)
        {
            try
            {
                return Context.Veiculo.FirstOrDefault(v => v.Id == id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Veiculo BuscarVeiculoPelaPlaca(string placa)
        {
            try
            {
                var veiculo = Context.Veiculo.FirstOrDefault(v => v.Placa == placa);
                if (veiculo != null) return veiculo;
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Veiculo AtualizarVeiculo(Veiculo veiculoParaAtualizar)
        {
            try
            {

                Context.Veiculo.Update(veiculoParaAtualizar);
                if (Context.SaveChanges() > 0) return veiculoParaAtualizar;
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool DeletarVeiculoPorId(int id)
        {
            try
            {
                var veiculoParaDeletar = Context.Motorista.FirstOrDefault(v => v.Id == id);
                if (veiculoParaDeletar != null) Context.Motorista.Remove(veiculoParaDeletar);
                else
                {
                    return false;
                }
                if (Context.SaveChanges() > 0) return true;
                return false;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
