using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using KooliProjekt.Data;
using KooliProjekt.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace KooliProjekt.IntegrationTests
{
    public class PostTests : TestBase
    {
        [Fact]
        public async Task Event_Create_EndpointReturnRedirectForCorrectModel()
        {
            // Arrange
            AuthenticateAdmin();
            var client = Factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            var formValues = new Dictionary<string, string>
            {
                { "event_name", "Test" },
                { "event_date_start", "1995-12-25 03:00:00" },
                { "event_date_end", "1995-12-25 06:00:00" },
                { "event_description", "Test" },
                { "user_Id", "1" },
                { "MaxParticipants", "250" },
                { "event_price", "10" },
                //{ "Id", $"{id}" }
            };




            var content = new FormUrlEncodedContent(formValues);


            // Act
            var response = await client.PostAsync("/Event/Create/", content);

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        }
        [Fact]
        public async Task Event_Create_EndpointReturnsOKForIncorrectModel()
        {
            // Arrange
            AuthenticateAdmin();
            var client = Factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            var formValues = new Dictionary<string, string>();
            formValues.Add("event_date_start", "qweqweqweqwe");
            var content = new FormUrlEncodedContent(formValues);

            // Act
            var response = await client.PostAsync("/Event/Create/", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Event_details_Create_EndpointReturnRedirectForCorrectModel()
        {
            // Arrange
            AuthenticateAdmin();
            var client = Factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            var @event = new Event { event_name = "TEST" };
            var user = new IdentityUser { Id = "1" };
            var context = GetDbContext();
            await context.AddAsync(@event);
            await context.SaveChangesAsync();

            var formValues = new Dictionary<string, string>
            {
                { "user_Id", user.Id },
                { "event_Id", @event.Id.ToString() },
                { "is_payed", "false" },
                //{ "Id", $"{id}" }
            };




            var content = new FormUrlEncodedContent(formValues);


            // Act
            var response = await client.PostAsync("/Event_details/Create/", content);

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        }
        [Fact]
        public async Task Event_details_Create_EndpointReturnsOKForIncorrectModel()
        {
            // Arrange
            AuthenticateAdmin();
            var client = Factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            var formValues = new Dictionary<string, string>
            {
                { "user_Id", "123456789" }
            };
            var content = new FormUrlEncodedContent(formValues);

            // Act
            var response = await client.PostAsync("/Event_details/Create/", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
