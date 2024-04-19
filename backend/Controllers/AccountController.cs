using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class AccountsController : ControllerBase
    {

        private readonly ProjectDbContext _dbContext;

        public AccountsController(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Account
        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts()
        {
            return _dbContext.Accounts.ToList();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(int id)
        {
            var account = _dbContext.Accounts.Find(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // POST: api/Account
        [HttpPost]
        public ActionResult<Account> PostAccount(Account account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();

            return CreatedAtAction("GetAccount", new { id = account.AccountID }, account);
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public IActionResult PutAccount(int id, Account account)
        {
            if (id != account.AccountID)
            {
                return BadRequest();
            }

            _dbContext.Entry(account).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            var account = _dbContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }

            _dbContext.Accounts.Remove(account);
            _dbContext.SaveChanges();

            return NoContent();
        }

    }
}

