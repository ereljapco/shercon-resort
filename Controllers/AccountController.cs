using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SherconResort.Web.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace SherconResort.Web.Controllers;

public class AccountController : Controller
{
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly UserManager<User> _userManager;
	private readonly SignInManager<User> _signInManager;

	public AccountController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager)
	{
		_roleManager = roleManager;
		_userManager = userManager;
		_signInManager = signInManager;
	}

	public IActionResult Index()
	{
		ViewData["Title"] = "Account Settings";

		return View();
	}

	[HttpGet]
	public IActionResult Register()
	{
		ViewData["Title"] = "Sign Up";

		return View();
	}

	[HttpPost]
	[AllowAnonymous]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Register(RegisterViewModel model)
	{
		if (ModelState.IsValid)
		{
			User user = new User
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				BirthDate = model.BirthDate,
				StreetAddress = model.StreetAddress,
				City = model.City,
				State = model.State,
				Country = model.Country,
				ZIPCode = model.ZIPCode,
				UserName = model.Email,
				Email = model.Email,
				RegistrationDate = DateTime.Now
			};

			IdentityResult result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				await _signInManager.SignInAsync(user, isPersistent: false);

				return RedirectToAction("Index", "Home");
			}
			else
			{
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
					Console.WriteLine(error.Description);
				}
			}

		}

		return View(model);
	}

	public IActionResult Login()
	{
		return View();
	}

	[HttpPost]
	[AllowAnonymous]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Login(LoginViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}

		var user = await _userManager.FindByEmailAsync(model.Email);

		if (user == null)
		{
			return View(model);
		}

		SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

		if (!result.Succeeded)
		{
			return View(model);
		}

		return RedirectToAction("Index", "Home");
	}

	[HttpPost]
	public async Task<IActionResult> Logout()
	{
		await _signInManager.SignOutAsync();

		return RedirectToAction("Index", "Home");
	}
}