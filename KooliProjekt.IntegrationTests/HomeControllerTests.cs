using System.Linq;
using System.Threading.Tasks;
using KooliProjekt.IntegrationTests.Helpers;
using Xunit;

namespace KooliProjekt.IntegrationTests
{
    public class HomeControllerTests : TestBase
    {
        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Privacy")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var claimsProvider = TestClaimsProvider.WithAdminClaims();
            using var client = Factory.CreateClientWithTestAuth(claimsProvider);

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/Home/Privacy")]

        public async Task Get_AnonymousCanAccessPrivacy(string url)
        {
            // Arrange
            using var client = Factory.CreateClient();

            // Act
            using var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());

        }

        [Fact]
        public async Task Get_Event()
        {
            // Arrange
            AuthenticateUser();
            var client = Factory.CreateClient();
            var dbContext = GetDbContext();

            // Act
            using var response = await client.GetAsync("/Event/");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());

        }

    }
}