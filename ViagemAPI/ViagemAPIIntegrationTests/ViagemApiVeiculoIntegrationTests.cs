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
        public async Task AdicionaVeiculoDeveriaRetornarObjetoValido()
        {
            //arrange
            var veiculoDto = new VeiculoDto()
            {
                
                Placa = "AWE-1111"
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
        public async Task DeletarVeiculoPorIdDeveriaExcluirLinhaCriada()
        {
            //arrange
            var veiculoDto = new VeiculoDto()
            {

                Placa = "AAA-1111"
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
            var veiculoParaAtualizar = new VeiculoDto()
            {
                Placa = "DDD-1111"
            };

            //act
            var motoristaAtualizado = await ViagemApiFixture.ViagemApiClient.AtualizarVeiculo(1, veiculoParaAtualizar);
            //assert
            Assert.Equal(veiculoParaAtualizar.Placa, motoristaAtualizado.Placa);
        }
    }
}
