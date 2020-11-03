using ContasAPagarAPI.Dtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ContasAPagarAPI.IntegrationTests
{
    public class ContasTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;

        public ContasTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task TestBuscaContasPagas()
        {
            var request = "/api/Contas";
            var response = await _client.GetAsync(request);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestBuscaContaPaga()
        {
            var request = "/api/Contas/9";
            var response = await _client.GetAsync(request);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestCriaContaPaga()
        {
            var request = new
            {
                Url = "/api/Contas",
                Body = new
                {
                    Nome = "Santander",
                    ValorOriginalStr = "50,00",
                    DataVencimentoStr = "2020-10-19",
                    DataPagamentoStr = "2020-10-18"
                }
            };

            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestAtualizaContaPaga()
        {
            var request = new
            {
                Url = "/api/Contas/9",
                Body = new
                {
                    Nome = "Santander",
                    ValorOriginalStr = "50,00",
                    DataVencimentoStr = "2020-10-19",
                    DataPagamentoStr = "2020-10-18"
                }
            };

            var response = await _client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestDeletaContaPaga()
        {
            var postRequest = new
            {
                Url = "/api/Contas",
                Body = new
                {
                    Nome = "Conta para deletar",
                    ValorOriginalStr = "50,00",
                    DataVencimentoStr = "2020-10-19",
                    DataPagamentoStr = "2020-10-18"
                }
            };

            var postResponse = await _client.PostAsync(postRequest.Url, ContentHelper.GetStringContent(postRequest.Body));

            var responseBuscaContaPaga = await _client.GetAsync(postResponse.Headers.Location.ToString());
            var jsonContaPagaCriada = await responseBuscaContaPaga.Content.ReadAsStringAsync();
            var contaPaga = JsonConvert.DeserializeObject<ContaPagaReadDto>(jsonContaPagaCriada);

            var deleteResponse = await _client.DeleteAsync(string.Format("/api/Contas/{0}", contaPaga.Id));

            postResponse.EnsureSuccessStatusCode();
            deleteResponse.EnsureSuccessStatusCode();
        }
    }
}
