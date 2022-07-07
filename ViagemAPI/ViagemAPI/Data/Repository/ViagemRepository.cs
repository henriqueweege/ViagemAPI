using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;
using ViagemAPI.Services;
using ViagemAPI.Services.ServicesContracts;

namespace ViagemAPI.Data.Repository
{
    public class ViagemRepository : IViagemRepository
    {
        public DataContext Context { get; set; }
        public IViagemServices Services { get; set; }
        public ViagemRepository(DataContext context, ViagemServices services)
        {
            Context = context;
            Services = services;
        }

        public Viagem CriarNovaViagem(ViagemDto viagemParaCriar)
        {
            try
            {
                var linhaMapeada = Services.TransformaDtoEmObjeto(viagemParaCriar);
                Context.Add(linhaMapeada);
                if (Context.SaveChanges() > 0) return Context.Viagem.OrderBy(v => v.Id).LastOrDefault(v => v.NumeroServico == viagemParaCriar.NumeroServico &&
                                                                                v.DataPartida == viagemParaCriar.DataPartida);
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IEnumerable<Viagem> BuscarTodasAsViagens()
        {
            try
            {
                IEnumerable<Viagem> viagensExistentes = Context.Viagem;
                if (viagensExistentes != null) return viagensExistentes;
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Viagem BuscarViagemPorId(int id)
        {
            try
            {
                return Context.Viagem.FirstOrDefault(l => l.Id == id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IEnumerable<Viagem> BuscarViagemPorData(DateTime dataDaViagem)
        {
            try
            {
                IEnumerable<Viagem> viagens = Context.Viagem.Where(v => v.DataPartida == dataDaViagem);
                if (viagens != null) return viagens;
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Viagem AtualizarViagem(Viagem viagemParaAtualizar)
        {
            try
            {

                Context.Viagem.Update(viagemParaAtualizar);
                if (Context.SaveChanges() > 0) return viagemParaAtualizar;
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool DeletarViagemPorId(int id)
        {
            try
            {
                var viagemParaDeletar = Context.Viagem.FirstOrDefault(l => l.Id == id);
                if (viagemParaDeletar != null) Context.Viagem.Remove(viagemParaDeletar);
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
