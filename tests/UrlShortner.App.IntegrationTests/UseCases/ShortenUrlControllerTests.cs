using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using UrlShortner.App.IntegrationTests.Configuration;
using Xunit;

namespace UrlShortner.App.IntegrationTests.UseCases
{
    public class ShortenUrlControllerTests
    {
        private HttpClient _httpClient;

        public ShortenUrlControllerTests()
        {
            var server = new ApplicationBuilder();
            _httpClient = server.CreateClient();
        }

        [Fact]
        public async Task CreateShortenUrlAsync_WhenOccurWithSuccess_ReturnShortenUrl()
        {
            // Arrange
            var requestUrl = "/api/shorten";

            var requestBody = new
            {
                Url = "https://localhost"
            };

            // Act
            var response = await _httpClient.PostAsJsonAsync(requestUrl, requestBody);

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await response.Content.ReadAsStringAsync();
            result.Should().NotBeNullOrEmpty();
        }
    }
}
