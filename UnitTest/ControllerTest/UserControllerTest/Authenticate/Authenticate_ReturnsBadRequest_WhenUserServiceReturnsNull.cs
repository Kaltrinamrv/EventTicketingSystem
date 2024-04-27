using Xunit;
using backend.Controllers;
using backend.IServices;
using backend.Models;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace UnitTest.ControllerTest.UserControllerTest.Authenticate
{
    public class Authenticate_ReturnsBadRequest_WhenUserServiceReturnsNull
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly UserController _controller;

        public Authenticate_ReturnsBadRequest_WhenUserServiceReturnsNull()
        {
            _mockUserService = new Mock<IUserService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new UserController(_mockUserService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task TestMethod()
        {
            var loginRequest = new UserLoginRequest { Email = "test@example.com", Password = "password" };
            _mockUserService.Setup(service => service.AuthenticateUser(loginRequest)).ReturnsAsync((UserResponse)null);

            var result = await _controller.Authenticate(loginRequest);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }
    }
}
