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
    public class Authenticate_ReturnsOk_WhenUserServiceReturnsUser
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly UserController _controller;

        public Authenticate_ReturnsOk_WhenUserServiceReturnsUser()
        {
            _mockUserService = new Mock<IUserService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new UserController(_mockUserService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task TestMethod()
        {
            var loginRequest = new UserLoginRequest { Email = "test@example.com", Password = "password" };
            var userResponse = new UserResponse { UserID = 1, Username = "testuser", Email = "test@example.com" };
            _mockUserService.Setup(service => service.AuthenticateUser(loginRequest)).ReturnsAsync(userResponse);

            var result = await _controller.Authenticate(loginRequest);

            Assert.IsType<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.Equal(userResponse, okResult.Value);
        }
    }
}
