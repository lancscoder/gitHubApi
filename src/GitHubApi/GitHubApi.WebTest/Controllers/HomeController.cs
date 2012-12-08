using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

//namespace Foo
//{
//
//	public class Bar
//	{
//		public void D()
//		{
//			GitHubApi.GitHubApi.Current;
//		}
//	}
//}

namespace GitHubApi.WebTest.Controllers
{
	public class HomeController : Controller
	{
		public async Task<ActionResult> Index()
		{
			var results = await GitHubApi.Current.Gists.PublicAsync();

			ViewBag.Message = results.Result.Count;

			return View();
		}

		public ActionResult Index2()
		{
			var results = GitHubApi.Current.Gists.Public();

			ViewBag.Message = results;

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
