using Microsoft.AspNetCore.Mvc;

namespace SherconResort.Web.Controllers;

public class RoomsController : Controller
{
	public ActionResult Index()
	{
		return View();
	}
}