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

            var placaCheckada = MesmaPlacaCheck(veiculoParaCriar.Placa);
            if (placaCheckada) throw new Exception("Placa já cadastrada.");

            var veiculoMapeado = Services.TransformaDtoEmVeiculo(veiculoParaCriar);
            Context.Add(veiculoMapeado);

            if (Context.SaveChanges() > 0) return Services.TransformaVeiculoEmViewModel(Context.Veiculo.OrderBy(v => v.Id)
                                                                                        .LastOrDefault(v => v.Placa == veiculoParaCriar.Placa));
            return null;

        }

        public IEnumerable<VeiculoViewModel> BuscarTodosOsVeiculos()
        {

            var veiculosExistentes = Context.Veiculo;
            if (veiculosExistentes != null) return Services.TransformaVeiculosEmViewModelList(veiculosExistentes);
            return null;
        }

        public VeiculoViewModel BuscarVeiculoPorId(int id)
        {
            var veiculoPesquisado = Context.Veiculo.FirstOrDefault(v => v.Id == id);

            if(veiculoPesquisado != null) return Services.TransformaVeiculoEmViewModel(veiculoPesquisado);
            return null;
        }

        public VeiculoViewModel BuscarVeiculoPelaPlaca(string placa)
        {

            var veiculo = Context.Veiculo.FirstOrDefault(v => v.Placa == placa);
            if (veiculo != null) return Services.TransformaVeiculoEmViewModel(veiculo);
            return null;


        }

        public VeiculoViewModel AtualizarVeiculo(int id, VeiculoDto veiculoParaAtualizar)
        {
            

            var veiculoConvertido = Services.TransformaDtoEmVeiculo(veiculoParaAtualizar);
            veiculoConvertido.Id = id;
            Context.Veiculo.Update(veiculoConvertido);
            if (Context.SaveChanges() > 0) return Services.TransformaVeiculoEmViewModel(veiculoConvertido);
            return null;


        }

        public bool DeletarVeiculoPorId(int id)
        {

            var veiculoParaDeletar = Context.Motorista.FirstOrDefault(v => v.Id == id);
            if (veiculoParaDeletar != null) Context.Motorista.Remove(veiculoParaDeletar);
            else return false;

            if (Context.SaveChanges() > 0) return true;
            return false;
        }

        private bool MesmaPlacaCheck(string placa)
        {

            var existeVeiculo = Context.Veiculo.FirstOrDefault(v => v.Placa == placa);
            if (existeVeiculo == null) return false;
            return true;

        }
    }
}
