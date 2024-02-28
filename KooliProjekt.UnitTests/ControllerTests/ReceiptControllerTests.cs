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
    public class ReceiptControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly Mock<IEvent_detailsService> _Event_detailsService;
        private readonly Mock<IEventService> _eventService;
        private readonly Mock<IReceiptService> _receiptService;
        private readonly ReceiptController _controller;

        public ReceiptControllerTests()
        {
            _context = new ApplicationDbContext();
            _Event_detailsService = new Mock<IEvent_detailsService>();
            _eventService = new Mock<IEventService>();
            _receiptService = new Mock<IReceiptService>();
            _controller = new ReceiptController(_context,
                                    _receiptService.Object,
                                    _eventService.Object,
                                    _Event_detailsService.Object
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
        // [Fact]
        // public async Task Details_should_return_view_and_model_if_todolist_was_found()
        // {
        //     // Arrange
        //     int id = 4;
        //     var item = new Event_details { Id = id };
        //     _Event_detailsService.Setup(srv => srv.GetById(id))
        //                         .ReturnsAsync(item);

        //     // Act
        //     var result = await _controller.Details(id) as ViewResult;

        //     // Assert
        //     Assert.NotNull(result);
        //     Assert.Equal(item, result.Model);
        // }
        // [Fact]
        // public async Task DeleteConfirmed_should_redirect_to_index()
        // {
        //     // Arrange
        //     int id = 4;
        //     _Event_detailsService.Setup(srv => srv.Delete(id))
        //                         .Verifiable();

        //     // Act
        //     var result = await _controller.DeleteConfirmed(id) as RedirectToActionResult;

        //     // Assert
        //     Assert.NotNull(result);
        //     Assert.Equal("Index", result.ActionName);
        //     _Event_detailsService.VerifyAll();
        // }
        /*[Fact]
        public async Task Pay_should_redirect_to_action_MyReceipts()
        {
            // Arrange
            int? id = 4;
            string loggedInUsername = "mina@example.com";
            _Event_detailsService.Setup(srv => srv.GetById(id.Value))
                                .ReturnsAsync(loggedInUsername);


            // Act

            // Assert

        }*/
    }
}
