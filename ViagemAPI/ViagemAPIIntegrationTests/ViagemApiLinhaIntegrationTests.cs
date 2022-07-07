

using ViagemApi.Client;

namespace ViagemAPIIntegrationTests
{
    public class ViagemApiLinhaIntegrationTests : IClassFixture<ViagemApiFixture>
    {
        public ViagemApiFixture ViagemApiFixture { get; set; }
        public ViagemApiLinhaIntegrationTests(ViagemApiFixture ViagemFixture)
        {
            ViagemApiFixture = ViagemFixture;
        }
        [Fact]
        public async Task AdicionarLinhaDeveriaRetornarObjetoValido()
        {
            //arrange
            var linhaDtoTest = new LinhaDto()
            {
                Nome = "LinhaTeste",
                Numero= 1,
                Origem="Qualquer",
                Destino="Qualquer 2"
            };

            //act
            var linhaResposta = await ViagemApiFixture.ViagemApiClient.AdicionarLinha(linhaDtoTest);


            //assert
            Assert.Equal(linhaDtoTest.Nome, linhaResposta.Nome);
        }

        [Fact]
        public async Task BuscarTodasAsLinhasDeveriaRetornarMaisDeUmObjetoValido()
        {
            //arrange
            //act
            IEnumerable<Linha> linhas = await ViagemApiFixture.ViagemApiClient.BuscarTodasAsLinha();
            
            //assert
            Assert.True(linhas.Count() > 1);

        }

        [Fact]
        public async Task BuscarLinhaPorIdDeveriaRetornarObjetoValido()
        {
            //arrange
            //act
            var linha = await ViagemApiFixture.ViagemApiClient.BuscarLinhaPorId(2);
            //assert
            Assert.NotNull(linha);
        }


        [Fact]
        public async Task DeletarLinhaPorIdDeveriaExcluirLinhaCriada()
        {
            //arrange
            var linhaDtoTest = new LinhaDto()
            {
                Nome = "LinhaTeste",
                Numero = 1,
                Origem = "Qualquer",
                Destino = "Qualquer 2"
            };
            var linhaResposta = await ViagemApiFixture.ViagemApiClient.AdicionarLinha(linhaDtoTest);

            //act
            await ViagemApiFixture.ViagemApiClient.DeletarLinhaPorId(linhaResposta.Id);
            var isCompleted =  ViagemApiFixture.ViagemApiClient.BuscarLinhaPorId(2).IsCompletedSuccessfully;
            //assert
            Assert.False(isCompleted);

            
        }

        [Fact]
        public async Task BuscarLinhaPorNumeroDeveriaRetornarObjetoValidoECorreto()
        {
            //arrange

            Random randNum = new Random();
           

            var linhaDtoTest = new LinhaDto()
            {
                Nome = "LinhaTeste",
                Numero = randNum.Next(),
                Origem = "Qualquer",
                Destino = "Qualquer 2"
            };
            var linhaCriada = await ViagemApiFixture.ViagemApiClient.AdicionarLinha(linhaDtoTest);
            //act
            var linhaBuscada = await ViagemApiFixture.ViagemApiClient.BuscarLinhaPorNumeroAsync(linhaDtoTest.Numero);

            //assert
            Assert.Equal(linhaBuscada.Id, linhaCriada.Id);
        }

        [Fact]
        public async Task AtualizarLinhaDeveriaRetornarObjetoValido()
        {
            //arrange
            var linhaParaAtualizar = new Linha()
            {
                Id = 1,
                Nome = "LinhaAtualizada",
                Numero = 8,
                Origem = "Qualquer",
                Destino = "Qualquer 2"
            };
            //act
            var linhaAtualizada = await ViagemApiFixture.ViagemApiClient.AtualizarLinha(linhaParaAtualizar);
            //assert
            Assert.Equal(linhaParaAtualizar.Nome, linhaAtualizada.Nome);
        }
    }
}