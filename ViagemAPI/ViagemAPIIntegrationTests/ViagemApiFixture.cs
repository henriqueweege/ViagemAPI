using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagemApi.Client;

namespace ViagemAPIIntegrationTests
{
    public class ViagemApiFixture : IDisposable
    {
        public ViagemApiClient ViagemApiClient { get; set; }
        public HttpClient HttpClient { get; set; }
        public ViagemApiFixture()
        {
            HttpClient = new HttpClient();
            ViagemApiClient = new ViagemApiClient("https://localhost:7158/", HttpClient);
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}
