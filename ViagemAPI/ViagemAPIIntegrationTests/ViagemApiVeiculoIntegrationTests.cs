using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagemAPI.Model;

namespace ViagemApiIntegrationTests
{
    public class ViagemApiVeiculoIntegrationTests : IClassFixture<ViagemApiFixture>
    {
        public ViagemApiFixture ViagemApiFixture { get; set; }
        public ViagemApiVeiculoIntegrationTests(ViagemApiFixture ViagemFixture)
        {
            ViagemApiFixture = ViagemFixture;
        }
        [Fact]
        public async Task AdicionarVeiculoDeveriaRetornarObjetoValido()
        {
            //arrange
            Random randNum = new Random();
            var veiculoDto = new CreateVeiculoDto()
            {
                
                Placa = $"AWE-{randNum.Next(0, 9)}{randNum.Next(0, 9)}{randNum.Next(0, 9)}{randNum.Next(0, 9)}"
            };

            //act
            var veiculoAdicionado = await ViagemApiFixture.ViagemApiClient.AdicionarVeiculo(veiculoDto);


            //assert
            Assert.Equal(veiculoDto.Placa, veiculoAdicionado.Placa);
        }

        [Fact]
        public async Task BuscarTodosOsVeiculosDeveriaRetornarMaisDeUmObjetoValido()
        {
            //arrange
            //act
           var veiculos = await ViagemApiFixture.ViagemApiClient.BuscarTodosOsVeiculos();

            //assert
            Assert.True(veiculos.Count() >= 1);

        }

        [Fact]
        public async Task BuscarVeiculoPorIdDeveriaRetornarObjetoValido()
        {
            //arrang
            //act
            var veiculo = await ViagemApiFixture.ViagemApiClient.BuscarVeiculoPorId(1);
            //assert
            Assert.True(veiculo.Placa != null);
        }


        [Fact]
        public async Task DeletarVeiculoPorIdDeveriaExcluirVeiculoCriado()
        {
            //arrange
            Random randNum = new Random();
            var veiculoDto = new CreateVeiculoDto()
            {

                Placa = $"AAA-{randNum.Next(0, 9)}{randNum.Next(0, 9)}{randNum.Next(0, 9)}{randNum.Next(0, 9)}"
            };
            var veiculoAdicionado = await ViagemApiFixture.ViagemApiClient.AdicionarVeiculo(veiculoDto);

            //act
            await ViagemApiFixture.ViagemApiClient.DeletarVeiculoPorId(veiculoAdicionado.Id);
            var existe = ViagemApiFixture.ViagemApiClient.BuscarVeiculoPorId(veiculoAdicionado.Id).IsCompletedSuccessfully;
            //assert
            Assert.False(existe);


        }

        [Fact]
        public async Task BuscarVeiculoPelaPlacaDeveriaRetornarObjetoValido()
        {
            //arrange

            var veiculo = await ViagemApiFixture.ViagemApiClient.BuscarVeiculoPorId(1);

            //act
            var veiculoPesquisado = await ViagemApiFixture.ViagemApiClient.BuscarVeiculoPelaPlaca(veiculo.Placa);

            //assert
            Assert.Equal(veiculoPesquisado.Id, veiculo.Id);
        }

        [Fact]
        public async Task AtualizarVeiculoDeveriaRetornarObjetoValido()
        {
            //arrange
            Random randNum = new Random();
            var veiculoParaAtualizar = new UpdateVeiculoDto()
            {
                Id= 1,
                Placa = $"DDD-{randNum.Next(0, 9)}{randNum.Next(0, 9)}{randNum.Next(0, 9)}{randNum.Next(0, 9)}"
            };

            //act
            var motoristaAtualizado = await ViagemApiFixture.ViagemApiClient.AtualizarVeiculo(veiculoParaAtualizar);
            //assert
            Assert.Equal(veiculoParaAtualizar.Placa, motoristaAtualizado.Placa);
        }

    }
}
