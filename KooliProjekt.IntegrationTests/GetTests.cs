using System;
using System.Net;
using System.Threading.Tasks;
using KooliProjekt.Data;
using KooliProjekt.IntegrationTests.Helpers;
using Xunit;

namespace KooliProjekt.IntegrationTests
{
    public class GetTests : TestBase
    {
        [Theory]
        [InlineData("/Event/Details/100")]
        [InlineData("/Event/Details/")]
        [InlineData("/Event/Edit/100")]
        [InlineData("/Event/Edit/")]
        [InlineData("/Event/Delete/100")]
        [InlineData("/Event/Delete/")]
        public async Task Get_returns_NotFound_when_list_was_not_found(string url)
        {
            // Arrange
            var client = Factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Theory]
        [InlineData("/Event/Details/")]
        [InlineData("/Event/Edit/")]
        [InlineData("/Event/Delete/")]
        public async Task Get_returns_OK_when_list_was_found(string url)
        {
            // Arrange
            var client = Factory.CreateClient();
            var @event = new Event { event_name = "TEST" };
            await DbContext.AddAsync(@event);
            await DbContext.SaveChangesAsync();

            Console.WriteLine("Event id: " + @event.Id);
            // Act
            var response = await client.GetAsync(url + @event.Id);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}