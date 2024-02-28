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
using Microsoft.AspNetCore.Http.HttpResults;


namespace KooliProjekt.UnitTests.ControllerTests
{
    public class EventAPIControllerTests
    {
        private readonly Mock<IEventService> _eventService;
        private readonly Mock<IEvent_detailsService> _event_DetailsService;
        private readonly Mock<IReceiptService> _receiptService;
        private readonly EventAPIController _controller;

        public EventAPIControllerTests()
        {
            _eventService = new Mock<IEventService>();
            _event_DetailsService = new Mock<IEvent_detailsService>();
            _receiptService = new Mock<IReceiptService>();
            _controller = new EventAPIController(
            _eventService.Object,
            _event_DetailsService.Object,
            _receiptService.Object
                                );
        }

        [Fact]
        public async Task GetEvent_should_return_event()
        {
            // Arrange
            int id = 4;
            Event @event = new Event();
            @event.Id = id;
            _eventService.Setup(r => r.GetById(id)).ReturnsAsync(@event);

            // Act
            var result = await _controller.GetEvent(id);
            // Assert
            Assert.IsType<ActionResult<Event>>(result);
            Assert.Equal(id, result.Value.Id);

        }
        [Fact]
        public async Task GetEvent_should_return_exeption_if_event_is_null()
        {
            // Arrange
            int id = 0;
            _eventService.Setup(r => r.GetById(id)).Equals(null);

            // Act
            var result = await _controller.GetEvent(id) as ActionResult<Event>;
            // Assert
            Assert.IsType<ActionResult<Event>>(result);


        }
        [Fact]
        public async Task PutEvent_should_return_BadRequest_if_id_is_incorrect()
        {
            // Arrange
            int id = 4;
            Event @event = new Event();
            @event.Id = 0;

            // Act
            var result = await _controller.PutEvent(id, @event) as BadRequestResult;
            // Assert
            Assert.IsType<BadRequestResult>(result);

        }
        [Fact]
        public async Task PutEvent_should_return_no_content()
        {
            // Arrange
            int id = 4;
            Event @event = new Event();
            @event.Id = id;
            _eventService.Setup(r => r.Entry(@event)).Verifiable();

            // Act
            var result = await _controller.PutEvent(id, @event);
            // Assert
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public async Task PutEvent_should_return_not_found_if_id_is_correct_and_event_does_not_exist()
        {
            // Arrange
            var id = 1;
            var @event = new Event { Id = id };
            _eventService.Setup(x => x.Entry(@event)).ThrowsAsync(new DbUpdateConcurrencyException());
            _eventService.Setup(x => x.EventExists(id)).Returns(false);
            // Act

            var result = await _controller.PutEvent(id, @event);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task PutEvent_should_return_exception_if_id_is_correct_and_event_exists()
        {
            // Arrange
            var id = 1;
            var @event = new Event { Id = id };
            _eventService.Setup(x => x.Entry(@event)).ThrowsAsync(new DbUpdateConcurrencyException());
            _eventService.Setup(x => x.EventExists(id)).Returns(true);
            var check = false;
            // Act
            try
            {
                var result = await _controller.PutEvent(id, @event);

            }
            catch (DbUpdateConcurrencyException)
            {
                check = true;
            }

            // Assert
            Assert.True(check);
        }
        [Fact]
        public async Task PostEvent_should_return_CreatedAtAction()
        {
            // Arrange
            var @event = new Event();
            _eventService.Setup(r => r.Save(@event)).Returns(Task.CompletedTask);

            // Act
            var createdResponse = await _controller.PostEvent(@event) as CreatedAtActionResult;
            // Assert
            // Assert.IsType<CreatedAtActionResult>(createdResponse);
            Assert.NotNull(createdResponse);
            
        }
        [Fact]
        public async Task DeleteEvent_should_delete_item_and_return_NoContent()
        {
            // Arrange
            int id = 1;
            var @event = new Event { Id = id };

            _eventService.Setup(r => r.Delete(id)).Verifiable();
            // Act
            var createdResponse = await _controller.DeleteEvent(id) as NoContentResult;
            // Assert
            Assert.IsType<NoContentResult>(createdResponse);
        }

    }
}
