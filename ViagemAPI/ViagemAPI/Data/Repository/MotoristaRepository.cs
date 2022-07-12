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

        public MotoristaRepository(DataContext context)
        {
            Context = context;
        }
        public Motorista CriarNovoMotorista(Motorista motoristaParaCriar)
        { 

            Context.Add(motoristaParaCriar);
            if (Context.SaveChanges() > 0) return Context.Motorista.OrderBy(m => m.Id).LastOrDefault(m => m.Cpf == motoristaParaCriar.Cpf);
            return null;

        }
        public Motorista BuscarMotoristaPorId(int id)
        {
            var motoristaBuscado = Context.Motorista.FirstOrDefault(l => l.Id == id);
            if(motoristaBuscado != null )  return motoristaBuscado;
            return null;
        }
        public Motorista BuscarMotoristaPeloCpf(string cpf)
        {

            var motorista = Context.Motorista.FirstOrDefault(m => m.Cpf == cpf);
            if (motorista != null) return motorista;
            return null;

        }
        public IEnumerable<Motorista> BuscarTodosOsMotoristas()
        {

            var motoristasExistentes = Context.Motorista.ToList();
            if (motoristasExistentes.ToList().Count > 0) return motoristasExistentes;
            return null;

        }

        public Motorista AtualizarMotorista(Motorista motoristaParaAtualizar)
        {

            Context.Motorista.Update(motoristaParaAtualizar);
            if (Context.SaveChanges() > 0) return motoristaParaAtualizar;
            return null;

        }
        

        public bool DeletarMotoristaPorId(int id)
        {

            var motoristaParaDeletar = Context.Motorista.FirstOrDefault(l => l.Id == id);
            if (motoristaParaDeletar != null) Context.Motorista.Remove(motoristaParaDeletar);
            else  return false;

            if (Context.SaveChanges() > 0) return true;
            return false;

        }

        public bool CheckarSeCpfEstaDiponivel(string cpf)
        {

            var existeMotorista = Context.Motorista.FirstOrDefault(m => m.Cpf == cpf);
            if(existeMotorista == null) return false;
            return true;

        }
    }
}
