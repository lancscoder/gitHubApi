using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubApi.WebTest.App_Start
{
	public class GitHubConfig
	{
		public static void RegisterGitHub()
		{
			// Add auth type here
			GitHubApi.Settings.Initialize();

			GitHubApi.Settings.Authentication = false;

		}
	}
}