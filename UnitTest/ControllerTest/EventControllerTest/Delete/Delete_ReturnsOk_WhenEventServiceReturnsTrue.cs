using AutoMapper;
using backend.Controllers;
using backend.IServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.ControllerTest.EventControllerTest.Delete
{
    public class Delete_ReturnsOk_WhenEventServiceReturnsTrue
    {
        private readonly Mock<IEventService> _mockEventService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly EventController _controller;

        public Delete_ReturnsOk_WhenEventServiceReturnsTrue()
        {
            _mockEventService = new Mock<IEventService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new EventController(_mockEventService.Object, _mockMapper.Object);
        }
    }
}
