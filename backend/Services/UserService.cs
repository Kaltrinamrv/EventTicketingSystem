using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.DataAccess;
using backend.Entities;
using backend.IServices;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


public class UserService : IUserService
{
    private readonly ProjectDbContext _context;
    private readonly IPasswordHashService _passwordHashService;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;


    public UserService(ProjectDbContext context, IPasswordHashService passwordHashService, ITokenService tokenService, IMapper mapper)
    {
        _context = context;
        _passwordHashService = passwordHashService;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public IEnumerable<UserResponse> GetAllUsers()
    {
        var users =  _context.Users.ToList();
        return _mapper.Map<IEnumerable<UserResponse>>(users);
       

    }
  

    public async Task<UserResponse> GetUserById(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserID == userId);
        return user != null ? MapUserToResponse(user) : null;
    }

    public async Task<UserResponse> CreateUser(CreateUserDto userDto) //register
    {
        
        var hashedPassword = _passwordHashService.HashPassword(userDto.Password);
        var newUser = new User
        {
            
            Username = userDto.Username,
            Email = userDto.Email,
            Password = hashedPassword,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            DateOfBirth = userDto.DateOfBirth,
            Address = userDto.Address,
            PhoneNumber = userDto.PhoneNumber
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return MapUserToResponse(newUser);
    }


    public async Task<UserResponse> UpdateUser(int userId, UpdateUserDto userDto)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserID == userId);
        if (existingUser == null)
            return null;

        existingUser.Username = userDto.Username ?? existingUser.Username;
        existingUser.Email = userDto.Email ?? existingUser.Email;
        existingUser.Password = userDto.Password ?? existingUser.Password;
        existingUser.FirstName = userDto.FirstName ?? existingUser.FirstName;
        existingUser.LastName = userDto.LastName ?? existingUser.LastName;
        existingUser.DateOfBirth = userDto.DateOfBirth != default ? userDto.DateOfBirth : existingUser.DateOfBirth;
        existingUser.Address = userDto.Address ?? existingUser.Address;
        existingUser.PhoneNumber = userDto.PhoneNumber ?? existingUser.PhoneNumber;

        await _context.SaveChangesAsync();

        return MapUserToResponse(existingUser);
    }

    public async Task<bool> DeleteUser(int userId)
    {
        var userToRemove = await _context.Users.FirstOrDefaultAsync(u => u.UserID == userId);
        if (userToRemove == null)
            return false;

        _context.Users.Remove(userToRemove);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<UserResponse> AuthenticateUser(UserLoginRequest loginRequest)  //login
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);
        if (user == null || !_passwordHashService.VerifyPassword(user.Password, loginRequest.Password))
        {
            // Invalid email or password
            return null;
        }

        // Authentication successful, generate token
        var token = _tokenService.GenerateToken(user.UserID);

        var userResponse = MapUserToResponse(user);
        userResponse.Token = token;
        return userResponse;
    }

    private UserResponse MapUserToResponse(User user)
    {
        return new UserResponse
        {
            UserID = user.UserID,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DateOfBirth = user.DateOfBirth,
            Address = user.Address,
            PhoneNumber = user.PhoneNumber
        };
    }
}

