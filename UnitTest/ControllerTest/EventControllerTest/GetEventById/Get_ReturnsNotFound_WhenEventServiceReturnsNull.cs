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
    public class Get_ReturnsNotFound_WhenEventServiceReturnsNull
    {
        private readonly Mock<IEventService> _mockEventService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly EventController _controller;

        public Get_ReturnsNotFound_WhenEventServiceReturnsNull()
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
            _mockEventService.Setup(service => service.GetEventById(eventId)).Returns((EventResponse) null);

            // Act
            var result = _controller.GetEventById(eventId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);  
        }    
    }
}
