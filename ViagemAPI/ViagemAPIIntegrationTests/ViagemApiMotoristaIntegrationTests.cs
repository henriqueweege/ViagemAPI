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
            Random randNum = new Random();
            //arrange
            var motoristaDto = new CreateMotoristaDto()
            {
                Nome = "MotoristaTeste",
                Cpf= $"0{randNum.Next(0, 9)}0{randNum.Next(0, 9)}00{randNum.Next(0, 9)}{randNum.Next(0, 9)}000"
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
            var motoristas = await ViagemApiFixture.ViagemApiClient.BuscarTodosOsMotoristas();

            //assert
            Assert.True(motoristas.Count() > 1);

        }

        [Fact]
        public async Task BuscarMotoristaPorIdDeveriaRetornarObjetoValido()
        {
            Random randNum = new Random();
            //arrange
            var motoristaDto = new CreateMotoristaDto()
            {
                Nome = "MotoristaTeste",
                Cpf = $"0{randNum.Next(0, 9)}0{randNum.Next(0, 9)}00{randNum.Next(0, 9)}{randNum.Next(0, 9)}000"
            };
            var motoristaAdicionado = await ViagemApiFixture.ViagemApiClient.AdicionarMotorista(motoristaDto);
            //act
            var motorista = await ViagemApiFixture.ViagemApiClient.BuscarMotoristaPorId(motoristaAdicionado.Id);
            //assert
            Assert.Equal(motorista.Cpf, motoristaDto.Cpf);
        }


        [Fact]
        public async Task DeletarMotoristaPorIdDeveriaExcluirMotoristaCriado()
        {
            Random randNum = new Random();
            //arrange
            var motoristaDto = new CreateMotoristaDto()
            {
                Nome = "MotoristaTeste",
                Cpf = $"0{randNum.Next(0, 9)}0{randNum.Next(0, 9)}00{randNum.Next(0, 9)}{randNum.Next(0, 9)}000"
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
            Random randNum = new Random();
            var motoristaDto = new CreateMotoristaDto()
            {
                Nome = "MotoristaTeste",
                Cpf = $"0{randNum.Next(0, 9)}0{randNum.Next(0, 9)}00{randNum.Next(0, 9)}{randNum.Next(0, 9)}000"
            };
            var motoristaAdicionado = await ViagemApiFixture.ViagemApiClient.AdicionarMotorista(motoristaDto);

            //act
            var motorista = await ViagemApiFixture.ViagemApiClient.BuscarMotoristaPorCpf(motoristaDto.Cpf);

            //assert
            Assert.Equal(motorista.Id, motoristaAdicionado.Id);
        }

        [Fact]
        public async Task AtualizarMotoristaDeveriaRetornarObjetoValido()
        {
            //arrange
            Random randNum = new Random();

            var motoristaParaAtualizar = new UpdateMotoristaDto()
            {
                Id= 3,
                Nome = "MotoristaAtualizado",
                Cpf = $"0{randNum.Next(0, 9)}0{randNum.Next(0, 9)}00{randNum.Next(0, 9)}{randNum.Next(0, 9)}000"
            };
            //act
            var motoristaAtualizado = await ViagemApiFixture.ViagemApiClient.AtualizarMotorista(motoristaParaAtualizar);
            //assert
            Assert.Equal(motoristaParaAtualizar.Cpf, motoristaAtualizado.Cpf);
        }
    }
}
