using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;
using ViagemAPI.Services;
using ViagemAPI.ViewModel;



namespace ViagemAPI.Data.Repository
{
    public class LinhaRepository : ILinhaRepository
    {
        public DataContext Context { get; set; }
        public LinhaRepository(DataContext context)
        {
            Context = context;
        }
        
        public Linha CriarNovaLinha(Linha linha)
        {

                Context.Add(linha);
                if (Context.SaveChanges() > 0) return  Context.Linha.OrderBy(l => l.Id).LastOrDefault(l => l.Numero == linha.Numero && 
                                                                                l.Nome == linha.Nome &&
                                                                                l.Origem == linha.Origem &&
                                                                                l.Destino == linha.Destino);
                return null;
        }

        public Linha BuscarLinhaPorId(int id)
        {

            var linhaBuscada = Context.Linha.FirstOrDefault(l => l.Id == id);
            if(linhaBuscada != null) return linhaBuscada;
            return null;

        }

        public IEnumerable<Linha> BuscarTodasAsLinhas()
        {

             IEnumerable<Linha> linhasExistentes = Context.Linha.ToList();
             if (linhasExistentes != null) return linhasExistentes;     
             return null;

        }
        public Linha BuscarLinhaPeloNumero(int numero)
        {

                var linha = Context.Linha.FirstOrDefault(l => l.Numero == numero);
                if (linha != null) return linha;
                return null;

        }

        public Linha AtualizarLinha(Linha linhaParaAtualizar)
        {
            
            Context.Linha.Update(linhaParaAtualizar);
            if (Context.SaveChanges() > 0) return linhaParaAtualizar;
            return null;
        }


        public bool DeletarLinhaPorId(int id)
        {

            var linhaParaDeletar = Context.Linha.FirstOrDefault(l => l.Id == id);
            if (linhaParaDeletar != null) Context.Linha.Remove(linhaParaDeletar);
            else return false;
            if (Context.SaveChanges() > 0) return true;
            return false;
        }
    }
}
