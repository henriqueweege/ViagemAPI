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
            var linhaDto = new LinhaDto()
            {
                Nome = "LinhaTeste",
                Numero= 1,
                Origem="Qualquer",
                Destino="Qualquer 2"
            };

            //act
            var linhaResposta = await ViagemApiFixture.ViagemApiClient.AdicionarLinha(linhaDto);


            //assert
            Assert.Equal(linhaDto.Nome, linhaResposta.Nome);
        }

        [Fact]
        public async Task BuscarTodasAsLinhasDeveriaRetornarMaisDeUmObjetoValido()
        {
            //arrange

            //act
            IEnumerable<LinhaViewModel> linhas = await ViagemApiFixture.ViagemApiClient.BuscarTodasAsLinha();
            
            //assert
            Assert.True(linhas.Count() > 1);

        }

        [Fact]
        public async Task BuscarLinhaPorIdDeveriaRetornarObjetoValido()
        {
            //arrange
            var linhaDto = new LinhaDto()
            {
                Nome = "LinhaTeste",
                Numero = 1,
                Origem = "Qualquer",
                Destino = "Qualquer 2"
            };

            var linhaAdicionada = await ViagemApiFixture.ViagemApiClient.AdicionarLinha(linhaDto);
            //act
            var linha = await ViagemApiFixture.ViagemApiClient.BuscarLinhaPorId(linhaAdicionada.Id);
            //assert
            Assert.Equal(linha.Nome, linhaDto.Nome);
        }


        [Fact]
        public async Task DeletarLinhaPorIdDeveriaExcluirLinhaCriada()
        {
            //arrange
            var linhaDto = new LinhaDto()
            {
                Nome = "LinhaTeste",
                Numero = 1,
                Origem = "Qualquer",
                Destino = "Qualquer 2"
            };
            var linhaResposta = await ViagemApiFixture.ViagemApiClient.AdicionarLinha(linhaDto);

            //act
            await ViagemApiFixture.ViagemApiClient.DeletarLinhaPorId(linhaResposta.Id);
            var existe =  ViagemApiFixture.ViagemApiClient.BuscarLinhaPorId(linhaResposta.Id).IsCompletedSuccessfully;
            //assert
            Assert.False(existe);

            
        }

        [Fact]
        public async Task BuscarLinhaPorNumeroDeveriaRetornarObjetoValido()
        {
            //arrange

            Random randNum = new Random();
           

            var linhaDto = new LinhaDto()
            {
                Nome = "LinhaTeste",
                Numero = randNum.Next(),
                Origem = "Qualquer",
                Destino = "Qualquer 2"
            };
            var linhaCriada = await ViagemApiFixture.ViagemApiClient.AdicionarLinha(linhaDto);
            //act
            var linhaBuscada = await ViagemApiFixture.ViagemApiClient.BuscarLinhaPorNumeroAsync(linhaDto.Numero);

            //assert
            Assert.Equal(linhaBuscada.Id, linhaCriada.Id);
        }

        [Fact]
        public async Task AtualizarLinhaDeveriaRetornarObjetoValido()
        {
            //arrange
            var linhaParaAtualizar = new LinhaDto()
            {
                Nome = "LinhaAtualizada",
                Numero = 8,
                Origem = "Qualquer",
                Destino = "Qualquer 2"
            };
            //act
            var linhaAtualizada = await ViagemApiFixture.ViagemApiClient.AtualizarLinha(1, linhaParaAtualizar);
            //assert
            Assert.Equal(linhaParaAtualizar.Nome, linhaAtualizada.Nome);
        }
    }
}