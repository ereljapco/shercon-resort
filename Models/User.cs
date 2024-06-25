using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SherconResort.Web.Models
{
	public class User
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime RegistrationDate { get; set; }

		public ICollection<Reservation> Reservations { get; set; }
	}
}