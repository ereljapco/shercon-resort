using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SherconResort.Web.Models;

namespace SherconResort.Web.Data
{
	public class ResortContext : IdentityDbContext<IdentityUser>
	{
		public ResortContext(DbContextOptions<ResortContext> options) : base(options)
		{ }

		public DbSet<Room> Rooms { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Review> Reviews { get; set; }
	}
}