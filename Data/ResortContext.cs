using Microsoft.EntityFrameworkCore;
using SherconResort.Web.Models;

namespace SherconResort.Web.Data
{
	public class ResortContext : DbContext
	{
		public ResortContext(DbContextOptions<ResortContext> options) : base(options)
		{ }

		public DbSet<User> Users { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Review> Reviews { get; set; }
	}
}