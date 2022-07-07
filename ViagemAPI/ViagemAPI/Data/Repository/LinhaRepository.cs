using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;
using ViagemAPI.Services;


namespace ViagemAPI.Data.Repository
{
    public class LinhaRepository : ILinhaRepository
    {
        public LinhaServices Services { get; set; }
        public DataContext Context { get; set; }
        public LinhaRepository(DataContext context, LinhaServices linhaServices)
        {
            Context = context;
            Services = linhaServices;
        }
        
        public Linha CriarNovaLinha(LinhaDto linhaDto)
        {
            try
            {
                var linhaMapeada = Services.TransformaDtoEmObjeto(linhaDto);
                Context.Add(linhaMapeada);
                if (Context.SaveChanges() > 0) return Context.Linha.OrderBy(l => l.Id).LastOrDefault(l => l.Numero == linhaDto.Numero && 
                                                                                l.Nome == linhaDto.Nome &&
                                                                                l.Origem == linhaDto.Origem &&
                                                                                l.Destino == linhaDto.Destino);
                return null;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public Linha BuscarLinhaPorId(int id)
        {
            try
            {
                return Context.Linha.FirstOrDefault(l => l.Id == id);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public IEnumerable<Linha> BuscarTodasAsLinhas()
        {
            try
            {
                IEnumerable<Linha> linhasExistentes = Context.Linha;
                if (linhasExistentes != null) return linhasExistentes;
                return null;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public Linha BuscarLinhaPeloNumero(int numero)
        {
            try
            {
                var linha = Context.Linha.FirstOrDefault(l => l.Numero == numero);
                if (linha != null) return linha;
                return null;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public Linha AtualizarLinha(Linha linhaParaAtualizar)
        {
            try
            {

                Context.Linha.Update(linhaParaAtualizar);
                if (Context.SaveChanges() > 0) return linhaParaAtualizar;
                return null;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }


        public bool DeletarLinhaPorId(int id)
        {
            try
            {
                var linhaParaDeletar = Context.Linha.FirstOrDefault(l => l.Id == id);
                if (linhaParaDeletar != null) Context.Linha.Remove(linhaParaDeletar);
                else
                {
                    return false;
                }
                if (Context.SaveChanges() > 0) return true;
                return false;

            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

    }
}
