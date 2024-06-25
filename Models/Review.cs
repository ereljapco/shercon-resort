using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SherconResort.Web.Models
{
	public class Review
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public int UserId { get; set; }

		[Required]
		public int RoomId { get; set; }

		[Required]
		[Range(1, 5, ErrorMessage = "The rating must be between 1 and 5.")]
		public int Rating { get; set; }

		[StringLength(250, ErrorMessage = "The comment must not exceed 250 characters.")]
		public string Comment { get; set; }

		public User User { get; set; }
		public Room Room { get; set; }
	}
}