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
    public class Delete_ReturnsNotFound_WhenUserServiceReturnsFalse
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly UserController _controller;

        public Delete_ReturnsNotFound_WhenUserServiceReturnsFalse()
        {
            _mockUserService = new Mock<IUserService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new UserController(_mockUserService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task TestMethod()
        {
            int userId = 1;
            _mockUserService.Setup(service => service.DeleteUser(userId)).ReturnsAsync(false);

            var result = await _controller.Delete(userId) as NotFoundObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }
    }
}
