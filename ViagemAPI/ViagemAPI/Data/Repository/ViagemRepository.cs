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

        public ViagemViewModel CriarNovaViagem(ViagemDto viagemParaCriarDto)
        {

           if(CheckarMesmoNumero(viagemParaCriarDto.NumeroServico, viagemParaCriarDto.DataPartida))
           {
                var viagemParaCriar = Services.TransformaDtoEmViagem(viagemParaCriarDto);
                Context.Add(viagemParaCriar);
                if(Context.SaveChanges() > 0)
                    return BuscarViagemPorId(viagemParaCriar.Id);
                throw new Exception("Erro na criação da viagem."); 
           }

           return null;

        }

        public IEnumerable<ViagemViewModel> BuscarTodasAsViagens()
        {

            IEnumerable<ViagemViewModel> viagensExistentes = (IEnumerable<ViagemViewModel>)
                (from viagens in Context.Viagem
                 join motorista in Context.Motorista 
                 on viagens.IdMotorista equals motorista.Id
                 join linha in Context.Linha 
                 on viagens.IdLinha equals linha.Id 
                 select new
                 {
                     Id = viagens.Id,
                     NumeroServico = viagens.NumeroServico,
                     NumeroLinha = linha.Numero,
                     Origem = linha.Origem,
                     Destino = linha.Destino,
                     NomeMotorista = motorista.Nome,
                     DataPartida = viagens.DataPartida,
                     DataChegada = viagens.DataChegada
                 });


            if (viagensExistentes != null) return viagensExistentes;
            return null;
        }

       

        public ViagemViewModel BuscarViagemPorId(int id)
        {
            ViagemViewModel viagensQuery = (ViagemViewModel)
                    (from viagens in Context.Viagem
                     join motorista in Context.Motorista
                     on viagens.IdMotorista equals motorista.Id
                     join linha in Context.Linha
                     on viagens.IdLinha equals linha.Id
                     where viagens.Id == id
                     select new
                     {
                         Id = viagens.Id,
                         NumeroServico = viagens.NumeroServico,
                         NumeroLinha = linha.Numero,
                         Origem = linha.Origem,
                         Destino = linha.Destino,
                         NomeMotorista = motorista.Nome,
                         DataPartida = viagens.DataPartida,
                         DataChegada = viagens.DataChegada
                     });


            if (viagensQuery != null) return viagensQuery;
            return null;
        }

        public IEnumerable<ViagemViewModel> BuscarViagemPorData(DateTime dataDaViagem)
        {

                IEnumerable<ViagemViewModel> viagensQuery = (IEnumerable<ViagemViewModel>)
                    (from viagens in Context.Viagem
                     join motorista in Context.Motorista
                     on viagens.IdMotorista equals motorista.Id
                     join linha in Context.Linha
                     on viagens.IdLinha equals linha.Id
                     where viagens.DataPartida == dataDaViagem
                     select new
                     {
                         Id = viagens.Id,
                         NumeroServico = viagens.NumeroServico,
                         NumeroLinha = linha.Numero,
                         Origem = linha.Origem,
                         Destino = linha.Destino,
                         NomeMotorista = motorista.Nome,
                         DataPartida = viagens.DataPartida,
                         DataChegada = viagens.DataChegada
                     });


                if (viagensQuery != null) return viagensQuery;
                return null;


            
        }

        public ViagemViewModel AtualizarViagem(int id, ViagemDto viagemParaAtualizarDto)
        {

            var viagemParaAtualizar = Services.TransformaDtoEmViagem(viagemParaAtualizarDto);
            viagemParaAtualizar.Id = id;
            Context.Viagem.Update(viagemParaAtualizar);

            if (Context.SaveChanges() > 0)
                return  BuscarViagemPorId(viagemParaAtualizar.Id);    
            else
                return null;
        }

        public bool DeletarViagemPorId(int id)
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


        public bool CheckarMesmoNumero(string numeroParaCheckar, DateTime dataPartida)
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
