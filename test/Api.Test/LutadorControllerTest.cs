using Api.Test.Order;
using ArtesMarciais.Core.DTO;
using ArtesMarciais.Core.Enum;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Api.Test
{
    [TestCaseOrderer("Api.Test.Order.PriorityOrderer", "Api.Test")]
    public class LutadorControllerTest : IClassFixture<CustomWebApplicationFactory>
    {
        private const string METHOD = "Lutador";

        private readonly HttpClient _httpClient;

        public LutadorControllerTest(CustomWebApplicationFactory webApplicationFactory)
        {
            _httpClient = webApplicationFactory.CreateClient();
        }

        [Fact, TestPriority(1)]
        public async Task RegistrarComSucesso()
        {
            // Arrange
            var request = new LutadorRegistrarDTO() { Nome = "Amanda Nunes", DataNascimento = new DateOnly(1988, 5, 30), Sexo = SexoEnum.Feminino, Altura = (decimal)1.73, Peso = (decimal)61.00 };

            // Act
            var result = await _httpClient.PostAsJsonAsync(METHOD, request);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.Created);

            var body = await result.Content.ReadAsStreamAsync();
            var response = await JsonDocument.ParseAsync(body);

            response.RootElement.GetProperty("nome").GetString().Should().Be(request.Nome);
            response.RootElement.GetProperty("id").GetInt32().Should().BeGreaterThan(0);
        }

        [Fact, TestPriority(2)]
        public async Task ListarComSucesso()
        {
            // Arrange e Act
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<LutadorDTO>>(METHOD);

            // Assert
            result.Should().NotBeEmpty();
        }
    }
}