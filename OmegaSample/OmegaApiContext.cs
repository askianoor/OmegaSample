using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OmegaSample.Models;
using System;

namespace OmegaSample
{
    public class OmegaApiContext : IdentityDbContext<UserEntity, UserRoleEntity, Guid>
    {
        public OmegaApiContext(DbContextOptions options) : base(options) { }

        public DbSet<RoomEntity> Rooms { get; set; }

        public DbSet<BookingEntity> Bookings { get; set; }
    }
}
