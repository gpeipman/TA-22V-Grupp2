using KooliProjekt.Controllers;
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
        [Fact]
        public void Error_should_return_error_view()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Error() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(string.IsNullOrEmpty(result.ViewName) ||
            result.ViewName == "Error");
        }
    }
}
