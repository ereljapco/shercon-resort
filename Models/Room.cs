using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SherconResort.Web.Models
{
	public enum AccomodationType
	{
		Daytour, Overnight
	}
	public enum RoomType
	{
		Kubo, Benches, Pavilion, Hall
	}
	public class Room
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "Room name cannot exceed 100 characters.")]
		public string Name { get; set; }

		[StringLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
		public string Description { get; set; }

		[Required]
		[EnumDataType(typeof(AccomodationType))]
		public string AccomodationType { get; set; }

		[Required]
		[EnumDataType(typeof(RoomType))]
		public string RoomType { get; set; }

		[Required]
		[Range(1, 100, ErrorMessage = "The maximum number of occupants must be between 1 and 100.")]
		public int MaxOccupants { get; set; }

		[Range(0, 10, ErrorMessage = "The number of bedrooms must be between 1 and 10.")]
		public int NumberofBedrooms { get; set; }

		[Required]
		[Range(0, 10, ErrorMessage = "The number of beds must be between 1 and 10.")]
		public int NumberOfBeds { get; set; }

		[Range(0, 10, ErrorMessage = "The number of bathrooms must be between 1 and 10.")]
		public int NumberOfBathRooms { get; set; }

		public bool HasKitchen { get; set; }

		public bool HasAircon { get; set; }

		[Required]
		[Range(1.00, 10000.00, ErrorMessage = "The price must be between 1.00 and 10000.00.")]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }

		[DataType(DataType.Date)]
		public DateTime CreateAt { get; set; }

		[DataType(DataType.Date)]
		public DateTime UpdatedAt { get; set; }

		public ICollection<Reservation> Reservations { get; set; }
		public ICollection<Review> Reviews { get; set; }
	}
}