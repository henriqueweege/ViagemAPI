using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagemAPI.Model;

namespace ViagemApiIntegrationTests
{
    public class ViagemApiViagemIntegrationTests:IClassFixture<ViagemApiFixture>
    {
        public ViagemApiFixture ViagemApiFixture { get; set; }
        public ViagemApiViagemIntegrationTests(ViagemApiFixture ViagemFixture)
        {
            ViagemApiFixture = ViagemFixture;
        }
        [Fact]
        public async Task AdicionaViagemDeveriaRetornarObjetoValido()
        {
            //arrange
            Random randNum = new Random();
            var viagemDto = new ViagemDto()
            {
                NumeroServico = $"{randNum.Next(0,100)}",
                IdLinha = 3,
                IdMotorista = 2,
                DataPartida = DateTime.Today,
                DataChegada = DateTime.Today
            };

            //act
            var viagemAdicionada = await ViagemApiFixture.ViagemApiClient.AdicionaViagem(viagemDto);


            //assert
            Assert.Equal(viagemDto.NumeroServico, viagemAdicionada.NumeroServico);
        }

        [Fact]
        public async Task BuscarTodasAsViagensDeveriaRetornarMaisDeUmObjetoValido()
        {
            //arrange
            //act
            IEnumerable<ViagemViewModel> veiculos = await ViagemApiFixture.ViagemApiClient.BuscarTodosAsViagens();

            //assert
            Assert.True(veiculos.Count() >= 1);

        }

        [Fact]
        public async Task BuscarViagemPeloIdDeveriaRetornarObjetoValido()
        {
            //arrange
            var viagemDto = new ViagemDto()
            {
                NumeroServico = "1234",
                IdLinha = 3,
                IdMotorista = 2,
                DataPartida = DateTime.Today,
                DataChegada = DateTime.Today
            };
            var viagemAdicionada = await ViagemApiFixture.ViagemApiClient.AdicionaViagem(viagemDto);
            //act
            var viagem = await ViagemApiFixture.ViagemApiClient.BuscarViagemPorId(viagemAdicionada.Id);
            //assert
            Assert.Equal(viagemAdicionada.Id, viagem.Id);
        }


        [Fact]
        public async Task DeletarViagemPorIdDeveriaExcluirLinhaCriada()
        {
            //arrange
            Random randNum = new Random();

            var viagemDto = new ViagemDto()
            {
                NumeroServico = $"{randNum.Next(1000, 100000)}",
                IdLinha = 3,
                IdMotorista = 2,
                DataPartida = DateTime.Today,
                DataChegada = DateTime.Today
            };
            var viagemAdicionada = await ViagemApiFixture.ViagemApiClient.AdicionaViagem(viagemDto);

            //act
            await ViagemApiFixture.ViagemApiClient.DeletarViagemPorId(viagemAdicionada.Id);
            var existe = ViagemApiFixture.ViagemApiClient.BuscarViagemPorId(viagemAdicionada.Id).IsCompletedSuccessfully;
            //assert
            Assert.False(existe);


        }

        [Fact]
        public async Task BuscarTodasAsViagensDeveriaRetornarMiasDeUmObjeto()
        {
            //arrange

            //act
            var viagens = await ViagemApiFixture.ViagemApiClient.BuscarTodosAsViagens();

            //assert
            Assert.True(viagens.Count()>=1);
        }

        [Fact]
        public async Task AtualizarVeiculoDeveriaRetornarObjetoValido()
        {
            Random randNum = new Random();

            var viagemParaAtualizar = new ViagemDto()
            {
                NumeroServico = $"{randNum.Next()}",
                IdLinha = 3,
                IdMotorista = 2,
                DataPartida = DateTime.Today,
                DataChegada = DateTime.Today
            };
            //act
            var viagemAtualizada = await ViagemApiFixture.ViagemApiClient.AtualizarViagem(1 ,viagemParaAtualizar);
            //assert
            Assert.Equal(viagemParaAtualizar.NumeroServico, viagemAtualizada.NumeroServico);
        }
    }
}
