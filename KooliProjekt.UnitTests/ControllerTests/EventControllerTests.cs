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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace KooliProjekt.UnitTests.ControllerTests
{
    public class EventControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly Mock<IEvent_detailsService> _Event_detailsService;
        private readonly Mock<IEventService> _eventService;
        private readonly Mock<IReceiptService> _receiptService;
        private readonly EventController _controller;

        public EventControllerTests()
        {
            _context = new ApplicationDbContext();
            _Event_detailsService = new Mock<IEvent_detailsService>();
            _eventService = new Mock<IEventService>();
            _receiptService = new Mock<IReceiptService>();
            _controller = new EventController(_context,
                                    _eventService.Object,
                                    _Event_detailsService.Object,
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
            Event event_details = null;
            _eventService.Setup(srv => srv.GetById(id))
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
            var item = new Event { Id = id };
            _eventService.Setup(srv => srv.GetById(id))
                                .ReturnsAsync(item);

            // Act
            var result = await _controller.Details(id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(item, result.Model);
        }

        // [Fact]
        // public async Task Create_should_return_view()
        // {
        //     // Arrange

        //     // Act
        //     SelectList ViewData = new SelectList(_context.Set<IdentityUser>(), "Id", "Id");
        //     var result = _controller.Create() as ViewResult;

        //     // Assert
        //     Assert.NotNull(result);
        //     Assert.Equal("Create", result.ViewName);
        // }

        [Fact]
        public async Task DeleteConfirmed_should_return_not_found_if_id_is_null()
        {
            // Arrange
            int? id = null;
            Event @event = null;
            // _eventService.Setup(srv => srv.GetById(id.Value))
            //                    .Returns(null);

            // Act
            var result = await _controller.Delete(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task Delete_should_return_not_found_if_id_is_not_null_but_event_doest_not_exist()
        {
            // Arrange
            int? id = 1;
            _eventService.Setup(srv => srv.GetById(id.Value))
                                .Equals(null);

            // Act
            var result = await _controller.Delete(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task Delete_should_return_view_if_id_is_not_null_and_event_exists()
        {
            // Arrange
            int? id = 1;
            Event @event = new Event { Id = id.Value };
            _eventService.Setup(srv => srv.GetById(id.Value))
                                .ReturnsAsync(@event);

            // Act
            var result = await _controller.Delete(id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async Task DeleteConfirmed_should_redirect_to_action_index()
        {
            // Arrange
            int id = 1;
            Event @event = new Event { Id = id };
            _eventService.Setup(srv => srv.Delete(id))
                                .Verifiable();

            // Act
            var result = await _controller.DeleteConfirmed(id) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<RedirectToActionResult>(result);
        }
        // [Fact]
        // public async Task Create_should_return_view()
        // {
        //     // Arrange
        //     _controller.FillTodoLists();
        //     // Act
        //     var result = _controller.Create() as ViewResult;

        //     // Assert
        //     Assert.NotNull(result);
        //     Assert.IsType<ViewResult>(result);
        //     // Assert.True(string.IsNullOrEmpty(result.ViewName) ||
        //     //  result.ViewName == "Create");
        // }
        [Fact]
        public async Task Create_redirects_to_action_if_model_is_valid()
        {
            // Arrange
            Event @event = new Event();
            _eventService.Setup(srv => srv.Save(@event));


            // Act
            var result = await _controller.Create(@event) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<RedirectToActionResult>(result);
        }
        //[Fact]
        //public async Task Create_creates_list_and_returns_view_if_model_is_invalid()
        //{
        //    // Arrange
        //    Event @event = new();
        //    _controller.ModelState.AddModelError("abc", "abc");
        //    // Act
        //    var result = await _controller.Create(@event) as ViewResult;
        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.IsType<ViewResult>(result);
        //}
        [Fact]
        public async Task Edit_returns_not_found_if_id_is_null()
        {
            // Arrange
            Event @event = new();
            // Act
            var result = await _controller.Edit(null) as NotFoundResult;
            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task Edit_returns_not_found_if_id_is_not_null_but_event_is_null()
        {
            // Arrange
            int id = 1;
            Event @event = new Event();
            _eventService.Setup(srv => srv.GetById(@event.Id)).ReturnsAsync(@event);
            // Act
            var result = await _controller.Edit(id) as NotFoundResult;
            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task Edit_returns_view_if_id_is_not_null_and_event_is_null()
        {
            // Arrange
            int id = 1;
            Event @event = new Event { Id = id };
            _eventService.Setup(srv => srv.GetById(@event.Id)).ReturnsAsync(@event);
            // Act
            var result = await _controller.Edit(id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async Task Edit_returns_not_found_if_id_is_not_equal_to_event_id()
        {
            // Arrange
            int id = 1;
            Event @event = new Event { Id = 2 };
            // Act
            var result = await _controller.Edit(id, @event) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
        //[Fact]
        //public async Task Edit_redirects_to_action_if_ModelState_is_valid()
        //{
        //    // Arrange
        //    int id = 1;
        //    Event @event = new Event { Id = id };
        //    _eventService.Setup(srv => srv.Save(@event)).Verifiable();


        //    // Act
        //    var result = await _controller.Edit(id, @event) as RedirectToActionResult;

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.IsType<RedirectToActionResult>(result);
        //}
        //[Fact]
        //public async Task Edit_catches_exeption()
        //{
        //    // Arrange
        //    int id = 1;
        //    Event @event = new Event { Id = id };
        //    bool check = false;
        //    _eventService.Setup(srv => srv.Save(@event)).Throws(new DbUpdateConcurrencyException());
        //    _eventService.Setup(srv => srv.EventExists(@event.Id)).Returns(true);
        //    // Act
        //    try
        //    {
        //        await _controller.Edit(id, @event);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        check = true;
        //    }
        //    // Assert
        //    Assert.True(check);
        //}
        //[Fact]
        //public async Task Edit_does_not_catch_an_exeption()
        //{
        //    // Arrange
        //    int id = 1;
        //    Event @event = new Event { Id = id };
        //    bool check = false;
        //    _eventService.Setup(srv => srv.Save(@event)).Throws(new DbUpdateConcurrencyException());
        //    _eventService.Setup(srv => srv.EventExists(@event.Id)).Returns(false);
        //    // Act
        //    try
        //    {
        //        await _controller.Edit(id, @event);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        check = true;
        //    }
        //    // Assert
        //    Assert.False(check);
        //}
        //[Fact]
        //public async Task Edit_returns_view_to_action_if_model_is_invalid()
        //{
        //    // Arrange
        //    int id = 1;
        //    Event @event = new Event { Id = id };
        //    _controller.ModelState.AddModelError("abc", "abc");
        //    _eventService.Setup(srv => srv.Save(@event)).Verifiable();
        //    // Act
        //    var result = await _controller.Edit(id, @event) as ViewResult;
        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.IsType<ViewResult>(result);
        //}
    }
}
