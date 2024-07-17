using Microsoft.AspNetCore.Identity;

namespace SherconResort.Web.Models
{
	public class User : IdentityUser
	{
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required DateTime BirthDate { get; set; }
		public string? StreetAddress { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Country { get; set; }
		public string? ZIPCode { get; set; }
		public DateTime RegistrationDate { get; set; }

		public ICollection<Reservation>? Reservations { get; set; }
	}
}