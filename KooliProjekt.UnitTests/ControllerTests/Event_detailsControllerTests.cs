using KooliProjekt.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using KooliProjekt.Services;
using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;


namespace KooliProjekt.UnitTests.ControllerTests
{
    public class Event_detailsControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly Mock<IEvent_detailsService> _Event_detailsService;
        private readonly Mock<IEventService> _eventService;
        private readonly Mock<IReceiptService> _receiptService;
        private readonly Event_detailsController _controller;

        public Event_detailsControllerTests()
        {
            _context = new ApplicationDbContext();
            _Event_detailsService = new Mock<IEvent_detailsService>();
            _eventService = new Mock<IEventService>();
            _receiptService = new Mock<IReceiptService>();
            _controller = new Event_detailsController(_context,
                                    _Event_detailsService.Object,
                                    _eventService.Object,
                                    _receiptService.Object
                                );
        }

        [Fact]
        public async Task Index_should_return_view()
        {
            // Arrange
            int page = 4;

            // Act
            var result = await _controller.Index(page) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(string.IsNullOrEmpty(result.ViewName) ||
             result.ViewName == "Index");

        }
        [Fact]
        public async Task Details_should_return_notfound_if_id_is_missing()
        {
            // Arrange
            int? id = null;

            // Act
            var result = await _controller.Details(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Details_should_return_notfound_if_item_was_not_found()
        {
            // Arrange
            var id = 4;
            Event_details event_details = null;
            _Event_detailsService.Setup(srv => srv.GetById(id))
                                .ReturnsAsync(event_details);

            // Act
            var result = await _controller.Details(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task Details_should_return_view_and_model_if_todolist_was_found()
        {
            // Arrange
            int id = 4;
            var item = new Event_details { Id = id };
            _Event_detailsService.Setup(srv => srv.GetById(id))
                                .ReturnsAsync(item);

            // Act
            var result = await _controller.Details(id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(item, result.Model);
        }
        [Fact]
        public async Task DeleteConfirmed_should_redirect_to_index()
        {
            // Arrange
            int id = 4;
            _Event_detailsService.Setup(srv => srv.Delete(id))
                                .Verifiable();

            // Act
            var result = await _controller.DeleteConfirmed(id) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            _Event_detailsService.VerifyAll();
        }
        [Fact]
        public async Task Register_should_redirect_to_MyEvent_details()
        {
            // Arrange
            int? id = 4;
            Event_details newRegistratedUser = new Event_details { Id = id.Value };

            _Event_detailsService.Setup(srv => srv.Save(newRegistratedUser))
            .Verifiable();

            // Act
            var result = await _controller.Register(id.Value) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("MyEvent_details", result.ActionName);
            _Event_detailsService.VerifyAll();
        }
        [Fact]
        public async Task Pay_should_redirect_to_action()
        {
            // Arrange
            int? id = 4;
            _Event_detailsService.Setup(srv => srv.GetById(id.Value))
                                .ReturnsAsync(new Event_details());

            // Act
            var result = await _controller.Pay(id.Value) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("MyEvent_details", result.ActionName);
            _Event_detailsService.VerifyAll();
        }
        [Fact]
        public async void MyEvent_details_should_return_view()
        {
            // Arrange
            _controller.ControllerContext.HttpContext = new DefaultHttpContext()
            {

                User = new GenericPrincipal(new GenericIdentity("testuser"), null)

            };

            _Event_detailsService.Setup(x => x.GetEvent_details("testuser")).ReturnsAsync(new List<Event_details>());

            // Act
            var result = await _controller.MyEvent_details() as ViewResult;

            // Assert
            Assert.NotNull(result);
            //Assert.True(string.IsNullOrEmpty(result.ViewName) ||
            // result.ViewName == "MyEvent_details");
        }
    }
}
