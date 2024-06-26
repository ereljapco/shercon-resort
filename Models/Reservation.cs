using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SherconResort.Web.Models
{
	public enum Status
	{
		Tentative,
		Confirmed,
		Cancelled,
		NoShow,
	}
	public class Reservation
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Required]
		public int RoomID { get; set; }

		[Required]
		public int UserID { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime StartDate { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime EndDate { get; set; }

		[Required]
		[Range(1, 100, ErrorMessage = "The total number of occupants must be between 1 and 100.")]
		public int TotalOccupants { get; set; }

		[Required]
		[Range(1.00, 10000.00, ErrorMessage = "The price must be between 1.00 and 10000.00.")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }

		[Required]
		[Range(1.00, 10000.00, ErrorMessage = "The price must be between 1.00 and 10000.00.")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal TotalPrice { get; set; }

		[Required]
		[EnumDataType(typeof(Status))]
		public required string Status { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime CreatedAt { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime UpdatedAt { get; set; }

		public required Room Room { get; set; }
		public required User User { get; set; }
	}
}