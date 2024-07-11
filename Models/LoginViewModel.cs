using System.ComponentModel.DataAnnotations;

namespace SherconResort.Web.Models;

public class LoginViewModel
{
	[Required]
	[EmailAddress]
	[Display(Name = "Email Address")]
	public required string Email { get; set; }

	[Required]
	[DataType(DataType.Password)]
	[Display(Name = "Password")]
	public required string Password { get; set; }

	[Display(Name = "Remember Me")]
	public bool RememberMe { get; set; }
}