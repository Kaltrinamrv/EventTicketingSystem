using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;



namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        
        private readonly ProjectDbContext _dbContext;

        public UsersController(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public object Login([FromBody] UserLoginRequest request)
        {
            var user = _dbContext.Users
                .Where(user => user.Email == request.Email)
                .Where(user => user.Password == request.Password)
                .FirstOrDefault();

            if (user == null)
            {
                return Unauthorized("Email or password did not match");
            }
            return Ok("token");
        }



        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _dbContext.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return NoContent();
        }
        
    }
    public class UserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
