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
            var viagemDto = new CreateViagemDto()
            {
                NumeroServico = $"{randNum.Next(0,100)}",
                IdLinha = 1,
                IdMotorista = 1,
                DataPartida = DateTime.Today,
                DataChegada = DateTime.Today
            };

            //act
            var viagemAdicionada = await ViagemApiFixture.ViagemApiClient.AdicionarViagem(viagemDto);


            //assert
            Assert.Equal(viagemDto.NumeroServico, viagemAdicionada.NumeroServico);
        }

        [Fact]
        public async Task BuscarTodasAsViagensDeveriaRetornarMaisDeUmObjetoValido()
        {
            //arrange
            //act
            IEnumerable<ReadViagemDto> veiculos = await ViagemApiFixture.ViagemApiClient.BuscarTodasAsViagens();

            //assert
            Assert.True(veiculos.Count() >= 1);

        }

        [Fact]
        public async Task BuscarViagemPeloIdDeveriaRetornarObjetoValido()
        {
            //arrange
            Random randNum = new Random();
            var viagemDto = new CreateViagemDto()
            {
                NumeroServico = $"{randNum.Next(0, 9)}{randNum.Next(0, 9)}{randNum.Next(0, 9)}{randNum.Next(0,9)}",
                IdLinha = 1,
                IdMotorista = 1,
                DataPartida = DateTime.Today,
                DataChegada = DateTime.Today
            };
            var viagemAdicionada = await ViagemApiFixture.ViagemApiClient.AdicionarViagem(viagemDto);
            //act
            var viagem = await ViagemApiFixture.ViagemApiClient.BuscarViagemPorId(viagemAdicionada.Id);
            //assert
            Assert.Equal(viagemAdicionada.Id, viagem.Id);
        }


        [Fact]
        public async Task DeletarViagemPorIdDeveriaExcluirViagemCriada()
        {
            //arrange
            Random randNum = new Random();

            var viagemDto = new CreateViagemDto()
            {
                NumeroServico = $"{randNum.Next(1000, 100000)}",
                IdLinha =1,
                IdMotorista = 1,
                DataPartida = DateTime.Today,
                DataChegada = DateTime.Today
            };
            var viagemAdicionada = await ViagemApiFixture.ViagemApiClient.AdicionarViagem(viagemDto);

            //act
            await ViagemApiFixture.ViagemApiClient.DeletarViagemPorId(viagemAdicionada.Id);
            var existe = ViagemApiFixture.ViagemApiClient.BuscarViagemPorId(viagemAdicionada.Id).IsCompletedSuccessfully;
            //assert
            Assert.False(existe);


        }

        [Fact]
        public async Task BuscarTodasAsViagensDeveriaRetornarMaisDeUmObjeto()
        {
            //arrange

            //act
            var viagens = await ViagemApiFixture.ViagemApiClient.BuscarTodasAsViagens();

            //assert
            Assert.True(viagens.Count()>=1);
        }

        [Fact]
        public async Task AtualizarViagemDeveriaRetornarObjetoValido()
        {
            Random randNum = new Random();

            var viagemParaAtualizar = new UpdateViagemDto()
            {
                Id=1,
                NumeroServico = $"{randNum.Next()}",
                IdLinha = 1,
                IdMotorista = 1,
                DataPartida = DateTime.Today,
                DataChegada = DateTime.Today
            };
            //act
            var viagemAtualizada = await ViagemApiFixture.ViagemApiClient.AtualizarViagem(viagemParaAtualizar);
            //assert
            Assert.Equal(viagemParaAtualizar.NumeroServico, viagemAtualizada.NumeroServico);
        }
    }
}
