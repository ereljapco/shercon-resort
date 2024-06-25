using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SherconResort.Web.Controllers;
public class AboutController : Controller
{
	public ActionResult Index()
	{
		return View();
	}
}