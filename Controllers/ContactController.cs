using Microsoft.AspNetCore.Mvc;

namespace SherconResort.Web.Controllers;

public class ContactController : Controller
{
	public ActionResult Index()
	{
		return View();
	}
}