using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;
using ViagemAPI.Services;
using ViagemAPI.Services.ServicesContracts;

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
        public Motorista CriarNovoMotorista(MotoristaDto motoristaParaCriar)
        {
            try
            {
                var linhaMapeada = Services.TransformaDtoEmObjeto(motoristaParaCriar);
                Context.Add(linhaMapeada);
                if (Context.SaveChanges() > 0) return Context.Motorista.OrderBy(m => m.Id).LastOrDefault(m => m.Cpf == motoristaParaCriar.Cpf);
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public Motorista BuscarMotoristaPorId(int id)
        {
            try
            {
                return Context.Motorista.FirstOrDefault(l => l.Id == id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public Motorista BuscarMotoristaPeloCpf(string cpf)
        {
            try
            {
                var motorista = Context.Motorista.FirstOrDefault(m => m.Cpf == cpf);
                if (motorista != null) return motorista;
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public IEnumerable<Motorista> BuscarTodosOsMotoristas()
        {
            try
            {
                IEnumerable<Motorista> motoristasExistentes = Context.Motorista;
                if (motoristasExistentes != null) return motoristasExistentes;
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Motorista AtualizarMotorista(Motorista motoristaParaAtualizar)
        {
            try
            {

                Context.Motorista.Update(motoristaParaAtualizar);
                if (Context.SaveChanges() > 0) return motoristaParaAtualizar;
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


        
    }
}
