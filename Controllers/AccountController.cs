using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SherconResort.Web.Models;

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
		return View();
	}

	[HttpGet]
	public IActionResult Register()
	{
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
					ModelState.AddModelError("", error.Description);
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

	// [HttpPost]
	// public async Task<IActionResult> Login(LoginViewModel model)
	// {
	// 	if (ModelState.IsValid)
	// 	{
	// 		@ViewData["LoginSucess"] = "Welcome back!";

	// 		return RedirectToAction("Index");
	// 	}
	// }
}