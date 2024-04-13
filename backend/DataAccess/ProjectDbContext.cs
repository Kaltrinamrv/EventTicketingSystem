using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.DataAccess
{
    public class ProjectDbContext : ProjectDbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
