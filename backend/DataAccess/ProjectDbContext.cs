﻿using Microsoft.EntityFrameworkCore;
using backend.Entities;
    

namespace backend.DataAccess
{
    public class ProjectDbContext : DbContext
    {
        // projectDb constructor
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


       

    }
}
