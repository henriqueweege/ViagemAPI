namespace ViagemAPIIntegrationTests
{
    public class UnitTest1 : IClassFixture<ViagemApiFixture>
    {
        public ViagemApiFixture ViagemApiFixture { get; set; }
        public UnitTest1(ViagemApiFixture ViagemFixture)
        {
            ViagemApiFixture = ViagemFixture;
        }
        [Fact]
        public async Task Test1()
        {
           var algumaCoisa = await ViagemApiFixture.ViagemApiClient.LinhaAsync();
            Console.WriteLine(algumaCoisa);
        }
    }
}