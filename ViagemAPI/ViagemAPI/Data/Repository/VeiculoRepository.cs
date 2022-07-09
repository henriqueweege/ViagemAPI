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
        public IVeiculoServices Services { get; set; }
        public VeiculoRepository(DataContext context, VeiculoServices services)
        {
            Context = context;
            Services = services;
        }

        public VeiculoViewModel CriarNovoVeiculo(VeiculoDto veiculoParaCriar)
        {
            try
            {
                var placaCheckada = MesmaPlacaCheck(veiculoParaCriar.Placa);
                if (placaCheckada == true) throw new Exception("Placa já cadastrado");
                var veiculoMapeado = Services.TransformaDtoEmVeiculo(veiculoParaCriar);
                Context.Add(veiculoMapeado);
                if (Context.SaveChanges() > 0) return Services.TransformaVeiculoEmViewModel(Context.Veiculo.OrderBy(v => v.Id)
                                                                                            .LastOrDefault(v => v.Placa == veiculoParaCriar.Placa));
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IEnumerable<VeiculoViewModel> BuscarTodosOsVeiculos()
        {
            try
            {
                var veiculosExistentes = Context.Veiculo;
                if (veiculosExistentes != null) return Services.TransformaVeiculosEmViewModelList(veiculosExistentes);
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public VeiculoViewModel BuscarVeiculoPorId(int id)
        {
            try
            {
                return Services.TransformaVeiculoEmViewModel(Context.Veiculo.FirstOrDefault(v => v.Id == id));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public VeiculoViewModel BuscarVeiculoPelaPlaca(string placa)
        {
            try
            {
                var veiculo = Context.Veiculo.FirstOrDefault(v => v.Placa == placa);
                if (veiculo != null) return Services.TransformaVeiculoEmViewModel(veiculo);
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public VeiculoViewModel AtualizarVeiculo(int id, VeiculoDto veiculoParaAtualizar)
        {
            try
            {

                var veiculoConvertido = Services.TransformaDtoEmVeiculo(veiculoParaAtualizar);
                veiculoConvertido.Id = id;
                Context.Veiculo.Update(veiculoConvertido);
                if (Context.SaveChanges() > 0) return Services.TransformaVeiculoEmViewModel(veiculoConvertido);
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

        private bool MesmaPlacaCheck(string placa)
        {
            try
            {
                var existeVeiculo = Context.Veiculo.FirstOrDefault(v => v.Placa == placa);
                if (existeVeiculo == null) return false;
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
