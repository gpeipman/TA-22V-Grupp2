using System.Diagnostics;
using KooliProjekt.Controllers;
using KooliProjekt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Xunit;

namespace KooliProjekt.UnitTests.ControllerTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_should_return_index_view()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(string.IsNullOrEmpty(result.ViewName) ||
             result.ViewName == "Index");

        }
        [Fact]
        public void Privacy_should_return_privacy_view()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Privacy() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(string.IsNullOrEmpty(result.ViewName) ||
            result.ViewName == "Privacy");

        }
        // [Fact]
        // public void Error_should_return_error_view()
        // {
        //     // Arrange
        //     var controller = new HomeController(null);
        //     var mockTraceIdentifier = "12345"; // Mocked TraceIdentifier
        //     var mockActivity = new Activity("mockActivity").SetIdFormat(ActivityIdFormat.W3C).Start();
        //     var mockHttpContext = new DefaultHttpContext();
        //     mockHttpContext.TraceIdentifier = mockTraceIdentifier;
        //     mockHttpContext.Features.Set(mockActivity);
        //     controller.ControllerContext = new ControllerContext { HttpContext = mockHttpContext };

        //     // Act
        //     var result = controller.Error() as ViewResult;
        //     var model = result?.Model as ErrorViewModel;

        //     // Assert
        //     Assert.NotNull(result);
        //     Assert.NotNull(model);
        //     Assert.Equal(mockTraceIdentifier, model.RequestId);
        // }
    }
}
