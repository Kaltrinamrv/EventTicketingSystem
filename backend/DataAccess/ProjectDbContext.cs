using Microsoft.EntityFrameworkCore;
using backend.Entities;

namespace backend.DataAccess
{
    public class ProjectDbContext : DbContext
    {
        // ProjectDbContext constructor
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EventID);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.DateTime).IsRequired();
                entity.Property(e => e.Location).IsRequired();
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)").IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderID);
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict); 
                entity.HasOne(e => e.Event)
                    .WithMany()
                    .HasForeignKey(e => e.EventID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict); // Restrict cascade delete
                entity.Property(e => e.TicketQuantity).IsRequired();
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.OrderDate).IsRequired();
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.TicketID);
                entity.HasOne(e => e.Event)
                    .WithMany()
                    .HasForeignKey(e => e.EventID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict); 
                entity.Property(e => e.IsAvailable).IsRequired();
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentID);
                entity.HasOne(e => e.Order)
                    .WithMany()
                    .HasForeignKey(e => e.OrderID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict); 
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.PaymentDate).IsRequired();
            });
        }




    }
}



