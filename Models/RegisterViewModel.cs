using System.ComponentModel.DataAnnotations;

namespace SherconResort.Web.Models;

public class RegisterViewModel
{
	[Required]
	[EmailAddress]
	[Display(Name = "Email Address")]
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