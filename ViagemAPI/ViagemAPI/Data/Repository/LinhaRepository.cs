using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;
using ViagemAPI.Services;


namespace ViagemAPI.Data.Repository
{
    public class LinhaRepository : ILinhaRepository
    {
        public LinhaServices LinhaServices { get; set; }
        public DataContext Context { get; set; }
        public LinhaRepository(DataContext context, LinhaServices linhaServices)
        {
            Context = context;
            LinhaServices = linhaServices;
        }
        
        public bool CriarNovaLinha(LinhaDto linhaDto)
        {
            try
            {
                var linhaMapeada = LinhaServices.TransformaDtoEmObjeto(linhaDto);
                Context.Add(linhaMapeada);
                if (Context.SaveChanges() > 0) return true;
                return false;
            }
            catch(Exception exception)
            {
                throw exception;
            }
            return true;
        }


        public bool AtualizarLinha(int id, LinhaDto veiculoToUpdate)
        {
            Context.Update(veiculoToUpdate);
            if (Context.SaveChanges() > 0) return true;
            return false;
        }

        public Linha BuscarLinhaPorId(int id)
        {
            throw new NotImplementedException();
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


        public bool DeletarLinhaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
