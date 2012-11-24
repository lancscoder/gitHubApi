using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GitHubApi.WebTest.Controllers
{
	public class HomeController : Controller
	{
		public async Task<ActionResult> Index()
		{
			using (var gist = new Gists())
			{
				var results = await gist.PublicAsync();

				var d = 0;

				ViewBag.Message = "";
					//results.Result;
			}

			return View();
		}

		public ActionResult Index2()
		{
			using (var gist = new Gists())
			{
				var results = gist.Public();

				ViewBag.Message = results;
			}

			return View("Index");
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your app description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}
