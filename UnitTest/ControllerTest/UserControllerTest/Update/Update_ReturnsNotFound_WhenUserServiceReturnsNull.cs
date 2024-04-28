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
    public class Update_ReturnsNotFound_WhenUserServiceReturnsNull
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly UserController _controller;

        public Update_ReturnsNotFound_WhenUserServiceReturnsNull()
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
            _mockUserService.Setup(service => service.UpdateUser(userId, userDto)).ReturnsAsync((UserResponse)null);

            var result = await _controller.Update(userId, userDto) as NotFoundObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }
    }
}
