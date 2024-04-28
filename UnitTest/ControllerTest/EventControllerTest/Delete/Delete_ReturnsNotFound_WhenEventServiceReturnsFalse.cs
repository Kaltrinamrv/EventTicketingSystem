using AutoMapper;
using backend.Controllers;
using backend.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.ControllerTest.EventControllerTest.Delete
{
    public class Delete_ReturnsNotFound_WhenEventServiceReturnsFalse
    {
        private readonly Mock<IEventService> _mockEventService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly EventController _controller;

        public Delete_ReturnsNotFound_WhenEventServiceReturnsFalse()
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
            _mockEventService.Setup(service => service.DeleteEvent(eventId)).Returns(false);

            // Act
            var result = _controller.DeleteEvent(eventId) as NotFoundObjectResult;
        }
    }
}
