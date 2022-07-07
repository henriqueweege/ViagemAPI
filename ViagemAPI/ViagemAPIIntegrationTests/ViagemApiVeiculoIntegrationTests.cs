using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                
                Placa = "AAA-1111"
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
            IEnumerable<Veiculo> veiculos = await ViagemApiFixture.ViagemApiClient.BuscarTodosOsVeiculos();

            //assert
            Assert.True(veiculos.Count() > 1);

        }

        [Fact]
        public async Task BuscarVeiculoPorIdDeveriaRetornarObjetoValido()
        {
            //arrange
            var veiculoDto = new VeiculoDto()
            {

                Placa = "AAA-1111"
            };
            var veiculoAdicionado = await ViagemApiFixture.ViagemApiClient.AdicionarVeiculo(veiculoDto);

            //act
            var veiculo = await ViagemApiFixture.ViagemApiClient.BuscarVeiculoPorId(veiculoAdicionado.Id);
            //assert
            Assert.Equal(veiculoDto.Placa, veiculo.Placa);
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
            var veiculoDto = new VeiculoDto()
            {

                Placa = "DDD-1111"
            };

            var veiculoAdicionado = await ViagemApiFixture.ViagemApiClient.AdicionarVeiculo(veiculoDto);

            //act
            var veiculoPesquisado = await ViagemApiFixture.ViagemApiClient.BuscarVeiculoPelaPlaca(veiculoDto.Placa);

            //assert
            Assert.Equal(veiculoPesquisado.Id, veiculoAdicionado.Id);
        }

        [Fact]
        public async Task AtualizarVeiculoDeveriaRetornarObjetoValido()
        {
            //arrange
            var veiculoParaAtualizar = new Veiculo()
            {
                Id=1,
                Placa = "DDD-1111"
            };

            //act
            var motoristaAtualizado = await ViagemApiFixture.ViagemApiClient.AtualizarVeiculo(veiculoParaAtualizar);
            //assert
            Assert.Equal(veiculoParaAtualizar.Placa, motoristaAtualizado.Placa);
        }
    }
}
