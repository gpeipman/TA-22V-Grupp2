using System;
using KooliProjekt.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.IntegrationTests.Helpers
{
    public abstract class TestBase : IDisposable
    {
        public WebApplicationFactory<FakeStartup> Factory { get; }
        public ApplicationDbContext DbContext { get; set; }
        public TestBase()
        {
            Factory = new TestApplicationFactory<FakeStartup>();
            DbContext = (ApplicationDbContext)Factory.Services.GetService(typeof(ApplicationDbContext));
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
        }

        // Add you other helper methods here
    }
}