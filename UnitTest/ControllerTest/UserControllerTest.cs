using Xunit;
using backend.Controllers;
using backend.IServices;
using backend.Models;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace backend.Tests
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new UserController(_mockUserService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Authenticate_ReturnsBadRequest_WhenUserServiceReturnsNull()
        {
            var loginRequest = new UserLoginRequest { Email = "test@example.com", Password = "password" };
            _mockUserService.Setup(service => service.AuthenticateUser(loginRequest)).ReturnsAsync((UserResponse)null);

            var result = await _controller.Authenticate(loginRequest);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task Authenticate_ReturnsOk_WhenUserServiceReturnsUser()
        {
            var loginRequest = new UserLoginRequest { Email = "test@example.com", Password = "password" };
            var userResponse = new UserResponse { UserID = 1, Username = "testuser", Email = "test@example.com" };
            _mockUserService.Setup(service => service.AuthenticateUser(loginRequest)).ReturnsAsync(userResponse);

            var result = await _controller.Authenticate(loginRequest);

            Assert.IsType<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.Equal(userResponse, okResult.Value);
        }

        [Fact]
        public async Task Register_ReturnsOk_WhenUserServiceReturnsUser()
        {
            var userDto = new CreateUserDto { Username = "testuser", Email = "test@example.com", Password = "password" };
            var userResponse = new UserResponse { UserID = 1, Username = "testuser", Email = "test@example.com" };
            _mockUserService.Setup(service => service.CreateUser(userDto)).ReturnsAsync(userResponse);

            var result = await _controller.Register(userDto);

            Assert.IsType<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.Equal(userResponse, okResult.Value);
        }
        /* Error to be fixed, DO NOT TOUCH
        [Fact]
        public void GetUsers_ReturnsOk_WithListOfUsers()
        {
            var expectedUsers = new List<UserResponse> { new UserResponse { UserID = 1, Username = "testuser1"}, new UserResponse { UserID = 2, Username = "testuser2" } };
            _mockUserService.Setup(service => service.GetAllUsers()).Returns(expectedUsers);

            var result = _controller.GetUsers();

            Assert.IsType<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var actualUsers = okResult.Value as List<UserResponse>;

            // Ensure the collection is not null before asserting
            Assert.NotNull(actualUsers);

            // Use Assert.Collection to assert each item in the collection
            Assert.Collection(actualUsers,
                user1 => Assert.Equal(expectedUsers[0].UserID, user1.UserID),
                user2 => Assert.Equal(expectedUsers[1].UserID, user2.UserID)
            );
        }*/

        [Fact]
        public async Task GetUserById_ReturnsNotFound_WhenUserServiceReturnsNull()
        {
            int userId = 1;
            _mockUserService.Setup(service => service.GetUserById(userId)).ReturnsAsync((UserResponse)null);

            var result = await _controller.GetUserById(userId);

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetUserById_ReturnsOk_WhenUserServiceReturnsUser()
        {
            int userId = 1;
            var userResponse = new UserResponse { UserID = 1, Username = "testuser", Email = "test@example.com" };
            _mockUserService.Setup(service => service.GetUserById(userId)).ReturnsAsync(userResponse);

            var result = await _controller.GetUserById(userId);

            Assert.IsType<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.Equal(userResponse, okResult.Value);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenUserServiceReturnsNull()
        {
            int userId = 1;
            var userDto = new UpdateUserDto { Username = "updateduser" };
            _mockUserService.Setup(service => service.UpdateUser(userId, userDto)).ReturnsAsync((UserResponse)null);

            var result = await _controller.Update(userId, userDto) as NotFoundObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public async Task Update_ReturnsOk_WhenUserServiceReturnsUser()
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

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenUserServiceReturnsFalse()
        {
            int userId = 1;
            _mockUserService.Setup(service => service.DeleteUser(userId)).ReturnsAsync(false);

            var result = await _controller.Delete(userId) as NotFoundObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public async Task Delete_ReturnsOk_WhenUserServiceReturnsTrue()
        {
            int userId = 1;
            _mockUserService.Setup(service => service.DeleteUser(userId)).ReturnsAsync(true);

            var result = await _controller.Delete(userId) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal("Deleted successfully!", result.Value);
        }

    }
}
