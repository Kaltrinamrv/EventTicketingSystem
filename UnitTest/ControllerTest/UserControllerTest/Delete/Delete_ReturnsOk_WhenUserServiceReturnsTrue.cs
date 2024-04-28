using Xunit;
using backend.Controllers;
using backend.IServices;
using backend.Models;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace UnitTest.ControllerTest.UserControllerTest.Delete
{
    public class Delete_ReturnsOk_WhenUserServiceReturnsTrue
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly UserController _controller;

        public Delete_ReturnsOk_WhenUserServiceReturnsTrue()
        {
            _mockUserService = new Mock<IUserService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new UserController(_mockUserService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task TestMethod()
        {
            int userId = 1;
            _mockUserService.Setup(service => service.DeleteUser(userId)).ReturnsAsync(true);

            var result = await _controller.Delete(userId) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
    }
}
