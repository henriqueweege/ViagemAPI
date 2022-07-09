using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;
using ViagemAPI.Services;
using ViagemAPI.Services.ServicesContracts;
using ViagemAPI.ViewModel;


namespace ViagemAPI.Data.Repository
{
    public class MotoristaRepository : IMotoristaRepository
    {
        public DataContext Context { get; set; }

        public IMotoristaServices Services { get; set; }
        public MotoristaRepository(DataContext context, MotoristaServices services)
        {
            Context = context;
            Services = services;
        }
        public MotoristaViewModel CriarNovoMotorista(MotoristaDto motoristaParaCriar)
        {
            try
            {
                var cpfCheckado = MesmoCpfCheck(motoristaParaCriar.Cpf);
                if (cpfCheckado == true) throw new Exception("Cpf já cadastrado");
                var linhaMapeada = Services.TransformaDtoEmMotorista(motoristaParaCriar);
                Context.Add(linhaMapeada);
                if (Context.SaveChanges() > 0) return Services.TransformaMotoristaEmViewModel(Context.Motorista.OrderBy(m => m.Id)
                                                                                            .LastOrDefault(m => m.Cpf == motoristaParaCriar.Cpf));
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public MotoristaViewModel BuscarMotoristaPorId(int id)
        {
            try
            {
                return Services.TransformaMotoristaEmViewModel(Context.Motorista.FirstOrDefault(l => l.Id == id));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public MotoristaViewModel BuscarMotoristaPeloCpf(string cpf)
        {
            try
            {
                var motorista = Context.Motorista.FirstOrDefault(m => m.Cpf == cpf);
                if (motorista != null) return Services.TransformaMotoristaEmViewModel(motorista);
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public IEnumerable<MotoristaViewModel> BuscarTodosOsMotoristas()
        {
            try
            {
                var motoristasExistentes = Context.Motorista.ToList();
                if (motoristasExistentes != null) return Services.TransformaMotoristasEmViewModelList(motoristasExistentes);
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MotoristaViewModel AtualizarMotorista(int id, MotoristaDto motoristaParaAtualizar)
        {
            try
            {
                var motoristaConvertido = Services.TransformaDtoEmMotorista(motoristaParaAtualizar);
                motoristaConvertido.Id = id;
                Context.Motorista.Update(motoristaConvertido);
                if (Context.SaveChanges() > 0) return Services.TransformaMotoristaEmViewModel(motoristaConvertido);
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        

        public bool DeletarMotoristaPorId(int id)
        {
            try
            {
                var motoristaParaDeletar = Context.Motorista.FirstOrDefault(l => l.Id == id);
                if (motoristaParaDeletar != null) Context.Motorista.Remove(motoristaParaDeletar);
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

        public bool MesmoCpfCheck(string cpf)
        {
            try
            {
                var existeMotorista = Context.Motorista.FirstOrDefault(m => m.Cpf == cpf);
                if(existeMotorista == null) return false;
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
