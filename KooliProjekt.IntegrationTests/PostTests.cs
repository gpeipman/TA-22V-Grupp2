using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using KooliProjekt.Data;
using KooliProjekt.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace KooliProjekt.IntegrationTests
{
    public class PostTests : TestBase
    {
        [Fact]
        public async Task Create_EndpointReturnRedirectForCorrectModel()
        {
            // Arrange
            AuthenticateAdmin();
            var client = Factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            int id = 1;

            var formValues = new Dictionary<string, string>
            {
                { "event_name", "Test" },
                { "event_date_start", "1995-12-25 03:00:00" },
                { "event_date_end", "1995-12-25 06:00:00" },
                { "event_description", "Test" },
                { "user_Id", "1" },
                { "MaxParticipants", "250" },
                { "event_price", "10" },
                { "Id", $"{id}" }
            };




            var content = new FormUrlEncodedContent(formValues);


            // Act
            var response = await client.PostAsync("/Event/Create/", content);

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        }
        [Fact]
        public async Task Create_EndpointReturnsOKForIncorrectModel()
        {
            // Arrange
            AuthenticateAdmin();
            var client = Factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            var formValues = new Dictionary<string, string>();



            var content = new FormUrlEncodedContent(formValues);

            // Act
            var response = await client.PostAsync("/Event/Create/", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
