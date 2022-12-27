using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.Metrics;
using RoomsReservation.Db.Models;
using Microsoft.Data.SqlClient;

namespace RoomsReservation.Db.Contexts
{
    public class RoomsReservationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public static RoomsReservationDbContext _context = new RoomsReservationDbContext();

        public RoomsReservationDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration;
        }

        public RoomsReservationDbContext(DbContextOptions options) : base(options)
        {

        }
        public RoomsReservationDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-GINQ8KH0;Initial Catalog=RoomsReservation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomManager> RoomManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RoomManager>()
                               .HasOne<Room>()
                               .WithMany()
                               .HasForeignKey(x => x.RoomId).IsRequired();
            builder.Entity<RoomManager>()
                        .HasOne<Manager>()
                        .WithMany()
                        .HasForeignKey(x => x.ManagerId).IsRequired();
            //builder.Entity<Reservation>()
            //            .HasOne<Manager>()
            //            .WithMany()
            //            .HasForeignKey(x => x.ManagerId).IsRequired();
            //builder.Entity<Reservation>()
            //            .HasOne<Room>()
            //            .WithMany()
            //            .HasForeignKey(x => x.RoomId).IsRequired();
            //builder.Entity<Reservation>()
            //    .HasOne<Member>()
            //    .WithMany()
            //    .HasForeignKey(x => x.MemberId).IsRequired();

            builder.Entity<Manager>()
                .Property(m => m.Username).IsRequired();
            builder.Entity<Manager>()
                .Property(m => m.Name).HasMaxLength(255);

            builder.Entity<Member>()
                .Property(me=>me.Username).IsRequired();
            builder.Entity<Member>()
                .Property(me => me.Name).HasMaxLength(255);

            builder.Entity<Room>()
                .Property(r=>r.Name).IsRequired().HasMaxLength(255);
        }

    }
}
