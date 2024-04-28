using Xunit;
using backend.Controllers;
using backend.IServices;
using backend.Models;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace UnitTest.ControllerTest.EventControllerTest.GetEventById
{
    public class Get_ReturnsOk_WhenEventServiceReturnsEvent
    {
        private readonly Mock<IEventService> _mockEventService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly EventController _controller;

        public Get_ReturnsOk_WhenEventServiceReturnsEvent()
        {
            _mockEventService = new Mock<IEventService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new EventController(_mockEventService.Object, _mockMapper.Object);
        }

        [Fact]
        public void TestMethod()
        {
            // Arrange
            int eventId = 10;
            var eventResponse = new EventResponse { EventID = eventId, Name = "BookEvent", Description = "Event about books" };
            _mockEventService.Setup(service => service.GetEventById(eventId)).Returns(eventResponse);

            // Act
            var result = _controller.GetEventById(eventId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(eventResponse, okResult.Value);
        }
    }
}
