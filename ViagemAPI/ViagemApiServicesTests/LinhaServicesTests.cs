using ViagemAPI.Data.Dto;
using ViagemAPI.Services;
using Xunit;

namespace ViagemApiServicesTest
{
    public class LinhaServicesTests
    {
        public LinhaServices LinhaServices { get; set; }
        public LinhaServicesTests(LinhaServices linhaServices)
        {
            LinhaServices = linhaServices;
        }
        [Fact]
        public void LinhaServicesDeveriaRetornarUmObjetoLinha()
        {
            //arrange
            var linhaDto = new LinhaDto()
            { 
                Nome= "Linha1",
                Numero= 1,
                Origem= "Corupá",
                Destino="Jaraguá do Sul"
            };
            //act
            var linha = LinhaServices.TransformaDtoEmObjeto(linhaDto);

            //assert
            Assert.Equal(linhaDto.Nome, linha.Nome);
        }

    }
}