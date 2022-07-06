using ViagemAPI.Data;
using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository;
using Xunit;

namespace ViagemApiRepositoryTests
{
    public class LinhaRepositoryTests : IClassFixture<LinhaRepository>
    {
        public LinhaRepository Repository { get; set; }
        public LinhaRepositoryTests(LinhaRepository repository)
        {
            Repository = repository;
        }
        [Fact]
        public void LinhaRepositoryDeveInserirNovaLinha()
        {
            //arrange
            var context = new DataContext();
            var novaLinha = new LinhaDto()
            {
                Nome = "Primeira Linha",
                Numero = 1,
                Origem = "Origem",
                Destino = "Destino"
            };

            //act

            var criandoNovaLinha = Repository.CriarNovaLinha(novaLinha);

            //assert

            Assert.True(criandoNovaLinha);
        }
    }
}