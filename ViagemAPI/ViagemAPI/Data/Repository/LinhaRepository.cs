using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;
using ViagemAPI.Services;
using ViagemAPI.ViewModel;



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
        
        public LinhaViewModel CriarNovaLinha(LinhaDto linhaDto)
        {
            try
            {
                var linhaMapeada = Services.TransformaDtoEmLinha(linhaDto);
                Context.Add(linhaMapeada);
                if (Context.SaveChanges() > 0) return Services.TransformaLinhaEmViewModel( Context.Linha.OrderBy(l => l.Id).LastOrDefault(l => l.Numero == linhaDto.Numero && 
                                                                                l.Nome == linhaDto.Nome &&
                                                                                l.Origem == linhaDto.Origem &&
                                                                                l.Destino == linhaDto.Destino));
                return null;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public LinhaViewModel BuscarLinhaPorId(int id)
        {
            try
            {
                return Services.TransformaLinhaEmViewModel(Context.Linha.FirstOrDefault(l => l.Id == id));
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public IEnumerable<LinhaViewModel> BuscarTodasAsLinhas()
        {
            try
            {
                IEnumerable<Linha> linhasExistentes = Context.Linha.ToList();
                if (linhasExistentes != null)
                {
                    var linhasConvertidas = Services.TransformaLinhasEmViewModelList(linhasExistentes);
                    if (linhasConvertidas != null) return linhasConvertidas.ToList();
                    throw new Exception("Erro na conversão.");
                }
                return null;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public LinhaViewModel BuscarLinhaPeloNumero(int numero)
        {
            try
            {
                var linha = Context.Linha.FirstOrDefault(l => l.Numero == numero);
                if (linha != null) return Services.TransformaLinhaEmViewModel(linha);
                return null;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public LinhaViewModel AtualizarLinha(int id, LinhaDto linhaParaAtualizar)
        {
            try
            {
                var linhaConvertida = Services.TransformaDtoEmLinha(linhaParaAtualizar);
                linhaConvertida.Id = id;
                Context.Linha.Update(linhaConvertida);
                if (Context.SaveChanges() > 0) return Services.TransformaLinhaEmViewModel(linhaConvertida);
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
