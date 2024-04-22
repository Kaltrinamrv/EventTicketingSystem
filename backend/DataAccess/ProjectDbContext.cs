﻿using Microsoft.EntityFrameworkCore;
using backend.Entities;


namespace backend.DataAccess
{
    public class ProjectDbContext : DbContext
    {
        // ProjectDbContext constructor
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Accounts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        // Model for configuring entity relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserID);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Event)
                .WithMany(e => e.Tickets)
                .HasForeignKey(t => t.EventID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Event)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.EventID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Ticket) 
                .WithMany()            
                .HasForeignKey(o => o.TicketID) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Payment>()
                .HasOne(a => a.User)
                .WithMany(u => u.Accounts)
                .HasForeignKey(a => a.UserID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
