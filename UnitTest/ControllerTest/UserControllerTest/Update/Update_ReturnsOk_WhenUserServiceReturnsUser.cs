using Xunit;
using backend.Controllers;
using backend.IServices;
using backend.Models;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace UnitTest.ControllerTest.UserControllerTest.Update
{
    public class Update_ReturnsOk_WhenUserServiceReturnsUser
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly UserController _controller;

        public Update_ReturnsOk_WhenUserServiceReturnsUser()
        {
            _mockUserService = new Mock<IUserService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new UserController(_mockUserService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task TestMethod()
        {
            int userId = 1;
            var userDto = new UpdateUserDto { Username = "updateduser" };
            var userResponse = new UserResponse { UserID = 1, Username = "updateduser", Email = "test@example.com" };
            _mockUserService.Setup(service => service.UpdateUser(userId, userDto)).ReturnsAsync(userResponse);

            var result = await _controller.Update(userId, userDto) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(userResponse, result.Value);
        }
    }
}
