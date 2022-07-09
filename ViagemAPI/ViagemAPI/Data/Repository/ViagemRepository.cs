using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;
using ViagemAPI.Services;
using ViagemAPI.Services.ServicesContracts;
using ViagemAPI.ViewModel;


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

        public ViagemViewModel CriarNovaViagem(ViagemDto viagemParaCriar)
        {
            try
            {
                var numeroViagemCheck = MesmoNumeroCheck(viagemParaCriar.NumeroServico, viagemParaCriar.DataPartida);
                var viagem = Services.TransformaDtoEmViagem(viagemParaCriar);
                var motoristaDaViagem = Context.Motorista.FirstOrDefault(m => m.Id == viagem.IdMotorista);
                var linhaDaViagem = Context.Linha.FirstOrDefault(l => l.Id == viagem.IdLinha);
                if (linhaDaViagem != null)
                {
                    Context.Add(viagem);
                    if(Context.SaveChanges() > 0)
                    {
                        ViagemViewModel viagemConvertida;
                        viagemConvertida = Services.TransformaViagemEmViewModel(viagem, linhaDaViagem, motoristaDaViagem);
                        return viagemConvertida;

                    }
                    else
                    {
                        throw new Exception("Erro na requisição.");
                    }

                }
                else
                {
                    throw new Exception("Linha inválida.");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IEnumerable<ViagemViewModel> BuscarTodasAsViagens()
        {
            try
            {
                var viagensExistentes = Context.Viagem.ToList();
                var viagensRetorno = new List<ViagemViewModel>();
                foreach (var viagem in viagensExistentes)
                {
                    var motoristaDaViagem = Context.Motorista.FirstOrDefault(m => m.Id == viagem.IdMotorista);
                    var linhaDaViagem = Context.Linha.FirstOrDefault(l => l.Id == viagem.IdLinha);
                    if (linhaDaViagem != null)
                        viagensRetorno.Add(Services.TransformaViagemEmViewModel(viagem, linhaDaViagem, motoristaDaViagem));
                    else throw new Exception("Linha ou Motorista invalidos.");
                }
                
                if (viagensRetorno != null) return viagensRetorno;
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ViagemViewModel BuscarViagemPorId(int id)
        {
            try
            {
                ViagemViewModel viagemConvertida;
                var viagemPesquisada = Context.Viagem.FirstOrDefault(l => l.Id == id);
                if(viagemPesquisada != null)
                {
                    var motoristaDaViagem = Context.Motorista.FirstOrDefault(m => m.Id == viagemPesquisada.IdMotorista);
                    var linhaDaViagem = Context.Linha.FirstOrDefault(l => l.Id == viagemPesquisada.IdLinha);
                    if(linhaDaViagem != null) 
                        viagemConvertida = Services.TransformaViagemEmViewModel(viagemPesquisada, linhaDaViagem, motoristaDaViagem);
                    else
                    {
                        throw new Exception("Motorista ou linha inválidos.");
                    }
                }
                else
                {
                    throw new Exception("Viagem não encontrada");
                }

                return viagemConvertida;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IEnumerable<ViagemViewModel> BuscarViagemPorData(DateTime dataDaViagem)
        {
            try
            {
                
                IEnumerable<Viagem> viagens = Context.Viagem.Where(v => v.DataPartida == dataDaViagem);
                IList<ViagemViewModel> viagensRetorno = new List<ViagemViewModel>();
                foreach (var viagem in viagens)
                {
                    var motoristaDaViagem = Context.Motorista.FirstOrDefault(m => m.Id == viagem.IdMotorista);
                    var linhaDaViagem = Context.Linha.FirstOrDefault(l => l.Id == viagem.IdLinha);
                    if (motoristaDaViagem != null && linhaDaViagem != null)
                        viagensRetorno.Add(Services.TransformaViagemEmViewModel(viagem, linhaDaViagem, motoristaDaViagem));
                    else throw new Exception("Linha ou Motorista invalidos.");
                }
                if (viagens != null) return viagensRetorno;
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ViagemViewModel AtualizarViagem(int id, ViagemDto viagemParaAtualizar)
        {
            try
            {
                var viagemAtualizada = Services.TransformaDtoEmViagem(viagemParaAtualizar);
                viagemAtualizada.Id = id;
                Context.Viagem.Update(viagemAtualizada);
                if (Context.SaveChanges() > 0)
                {
                    ViagemViewModel viagemConvertida;
                    var viagemPesquisada = Context.Viagem.FirstOrDefault(l => l.Id == id);
                    if (viagemPesquisada != null)
                    {
                        var motoristaDaViagem = Context.Motorista.FirstOrDefault(m => m.Id == viagemPesquisada.IdMotorista);
                        var linhaDaViagem = Context.Linha.FirstOrDefault(l => l.Id == viagemPesquisada.IdLinha);
                        if (motoristaDaViagem != null && linhaDaViagem != null)
                            viagemConvertida = Services.TransformaViagemEmViewModel(viagemPesquisada, linhaDaViagem, motoristaDaViagem);
                            
                        else
                        {
                            throw new Exception("Motorista ou linha inválidos.");
                        }
                        return viagemConvertida;
                    }
                    else
                    {
                        throw new Exception("Viagem não encontrada");
                    }

                }
                else
                {
                    throw new Exception("Erro na atualização.");
                }


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

        public bool MesmoNumeroCheck(string numeroParaCheckar, DateTime dataPartida)
        {
            IEnumerable<Viagem> viagensComEsseNumero = Context.Viagem.Where(v => v.NumeroServico == numeroParaCheckar);
            foreach(var viagem in viagensComEsseNumero)
            {
                if (viagem.DataPartida == dataPartida) throw new Exception("Números de serviço devem ser únicos no dia.");
            }
            return false;
        }
    }
}
