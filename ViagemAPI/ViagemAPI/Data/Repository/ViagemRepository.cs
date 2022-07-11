using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Dto.Viagem;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;
using ViagemAPI.Services;
using ViagemAPI.Services.ServicesContracts;


namespace ViagemAPI.Data.Repository
{
    public class ViagemRepository : IViagemRepository
    {
        public DataContext Context { get; set; }

        public ViagemRepository(DataContext context)
        {
            Context = context;

        }

        public ReadViagemDto CriarNovaViagem(Viagem viagemParaCriar)
        {

                
                Context.Add(viagemParaCriar);
                if(Context.SaveChanges() > 0)
                    return BuscarViagemPorId(viagemParaCriar.Id);
                throw new Exception("Erro na criação da viagem."); 


           return null;

        }

        public IEnumerable<ReadViagemDto> BuscarTodasAsViagens()
        {

            var viagensExistentes =
                from viagens in Context.Viagem
                join linha in Context.Linha
                on viagens.IdLinha equals linha.Id
                join motorista in Context.Motorista
                on viagens.IdMotorista equals motorista.Id into motoristaQuery
                from motorista in motoristaQuery.DefaultIfEmpty()
                select new ReadViagemDto()
                 {
                     Id = viagens.Id,
                     NumeroServico = viagens.NumeroServico,
                     NumeroLinha = linha.Numero,
                     Origem = linha.Origem,
                     Destino = linha.Destino,
                     NomeMotorista = motorista.Nome,
                     DataPartida = viagens.DataPartida,
                     DataChegada = viagens.DataChegada
                 };

            if(viagensExistentes.ToList().Count > 0) return viagensExistentes;
            return null;

        }

       

        public ReadViagemDto BuscarViagemPorId(int id)
        {
            var viagensQuery = 
                    (from viagens in Context.Viagem
                     join linha in Context.Linha
                     on viagens.IdLinha equals linha.Id
                     join motorista in Context.Motorista
                     on viagens.IdMotorista equals motorista.Id into motoristaQuery
                     from motorista in motoristaQuery.DefaultIfEmpty()
                     where viagens.Id == id
                     select new ReadViagemDto()
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


            return viagensQuery.First();

        }

        public IEnumerable<ReadViagemDto> BuscarViagemPorData(DateTime dataDaViagem)
        {

                var viagensQuery = 
                    from viagens in Context.Viagem
                    join linha in Context.Linha
                    on viagens.IdLinha equals linha.Id
                    join motorista in Context.Motorista
                    on viagens.IdMotorista equals motorista.Id into motoristaQuery
                    from motorista in motoristaQuery.DefaultIfEmpty()
                    where viagens.DataPartida == dataDaViagem
                     select new ReadViagemDto()
                     {
                         Id = viagens.Id,
                         NumeroServico = viagens.NumeroServico,
                         NumeroLinha = linha.Numero,
                         Origem = linha.Origem,
                         Destino = linha.Destino,
                         NomeMotorista = motorista.Nome,
                         DataPartida = viagens.DataPartida,
                         DataChegada = viagens.DataChegada
                     };

            if (viagensQuery.ToList().Count > 0) return viagensQuery;
            return null;



            
        }

        public ReadViagemDto AtualizarViagem(Viagem viagemParaAtualizar)
        {

            
            Context.Viagem.Update(viagemParaAtualizar);

            if (Context.SaveChanges() > 0)
                return  BuscarViagemPorId(viagemParaAtualizar.Id);    
            
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
                if (viagem.DataPartida.Year == dataPartida.Year &&
                    viagem.DataPartida.Month == dataPartida.Month &&
                    viagem.DataPartida.Day == dataPartida.Day) return false;
            }
            return true;
        }


    }
}
