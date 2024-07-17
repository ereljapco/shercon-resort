using System.ComponentModel.DataAnnotations;

namespace SherconResort.Web.Models;

public class RegisterViewModel
{
	[Required]
	[Display(Name = "First name")]
	public required string FirstName { get; set; }

	[Required]
	[Display(Name = "Last name")]
	public required string LastName { get; set; }

	[Required]
	[DataType(DataType.Date)]
	[Display(Name = "Birthdate")]
	public required DateTime BirthDate { get; set; }

	[Display(Name = "Street address")]
	public string? StreetAddress { get; set; }

	[Display(Name = "City")]
	public string? City { get; set; }

	[Display(Name = "State / Province / County / Region")]
	public string? State { get; set; }

	[Display(Name = "Country")]
	public string? Country { get; set; }

	[Display(Name = "ZIP Code")]
	public string? ZIPCode { get; set; }

	[Required]
	[EmailAddress]
	public required string Email { get; set; }

	[Required]
	[DataType(DataType.Password)]
	[Display(Name = "Password")]
	public required string Password { get; set; }

	[Required]
	[DataType(DataType.Password)]
	[Display(Name = "Confirm Password")]
	[Compare("Password", ErrorMessage = "The password and the confirmation password did not match.")]
	public required string ConfirmPassword { get; set; }
}