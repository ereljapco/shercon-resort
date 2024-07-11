using Microsoft.AspNetCore.Identity;

namespace SherconResort.Web.Models
{
	public class User : IdentityUser
	{
		public DateTime RegistrationDate { get; set; }

		public ICollection<Reservation>? Reservations { get; set; }
	}
}