using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagemApiIntegrationTests
{
    public class ViagemApiMotoristaIntegrationTests : IClassFixture<ViagemApiFixture>
    {
        public ViagemApiFixture ViagemApiFixture { get; set; }
        public ViagemApiMotoristaIntegrationTests(ViagemApiFixture ViagemFixture)
        {
            ViagemApiFixture = ViagemFixture;
        }

        [Fact]
        public async Task AdicionarMotoristaDeveriaRetornarObjetoValido()
        {
            //arrange
            var motoristaDto = new MotoristaDto()
            {
                Nome = "MotoristaTeste",
                Cpf= "000.000.000-00"
            };

            //act
            var motoristaAdicionado = await ViagemApiFixture.ViagemApiClient.AdicionarMotorista(motoristaDto);


            //assert
            Assert.Equal(motoristaDto.Cpf, motoristaAdicionado.Cpf);
        }

        [Fact]
        public async Task BuscarTodosOsMotoristasDeveriaRetornarMaisDeUmObjetoValido()
        {
            //arrange
            //act
            IEnumerable<Motorista> motoristas = await ViagemApiFixture.ViagemApiClient.BuscarTodosOsMotoristas();

            //assert
            Assert.True(motoristas.Count() > 1);

        }

        [Fact]
        public async Task BuscarMotoristaPorIdDeveriaRetornarObjetoValido()
        {
            //arrange
            var motoristaDto = new MotoristaDto()
            {
                Nome = "MotoristaTeste",
                Cpf = "000.000.000-00"
            };
            var motoristaAdicionado = await ViagemApiFixture.ViagemApiClient.AdicionarMotorista(motoristaDto);
            //act
            var motorista = await ViagemApiFixture.ViagemApiClient.BuscarMotoristaPorId(motoristaAdicionado.Id);
            //assert
            Assert.Equal(motorista.Cpf, motoristaDto.Cpf);
        }


        [Fact]
        public async Task DeletarMotoristaPorIdDeveriaExcluirLinhaCriada()
        {
            //arrange
            var motoristaDto = new MotoristaDto()
            {
                Nome = "MotoristaTeste",
                Cpf = "000.000.000-00"
            };

            //act
            var motoristaAdicionado = await ViagemApiFixture.ViagemApiClient.AdicionarMotorista(motoristaDto);

            //act
            await ViagemApiFixture.ViagemApiClient.DeletarMotoristaPorId(motoristaAdicionado.Id);
            var existe = ViagemApiFixture.ViagemApiClient.BuscarLinhaPorId(motoristaAdicionado.Id).IsCompletedSuccessfully;
            //assert
            Assert.False(existe);


        }

        [Fact]
        public async Task BuscarMotoristaPorCpfDeveriaRetornarObjetoValido()
        {
            //arrange
            //act
            var motorista = await ViagemApiFixture.ViagemApiClient.BuscarMotoristaPorCpf("888.999.999-99");

            //assert
            Assert.True(motorista.Cpf != null);
        }

        [Fact]
        public async Task AtualizarMotoristaDeveriaRetornarObjetoValido()
        {
            //arrange
            var motoristaParaAtualizar = new Motorista()
            {
                Id = 1,
                Nome = "MotoristaAtualizada",
                Cpf = "888.888.888-88"
            };
            //act
            var motoristaAtualizado = await ViagemApiFixture.ViagemApiClient.AtualizarMotorista(motoristaParaAtualizar);
            //assert
            Assert.Equal(motoristaParaAtualizar.Cpf, motoristaAtualizado.Cpf);
        }
    }
}
