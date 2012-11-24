using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi
{
	public class GitHubApi
	{
		public enum Mode
		{

		}

		public static class Settings
		{
			private static string _apiUrl = "https://api.github.com";
			public static string ApiUrl { get { return _apiUrl; } }

			// THe tyoe if authentication - need to redo name
			public static bool Authentication { get; set; }

			/// <summary>
			/// Required string - The client ID you received from GitHub when you registered.
			/// https://github.com/settings/applications/new
			/// </summary>
			public static string ClientId { get; set; }

			// TODO : Scope for oauth..

			/// <summary>
			/// An unguessable random string. It is used to protect against cross-site request forgery attacks.
			/// </summary>
			public static string State { get; set; }

			public static void Initialize()
			{
			}
		}
	}
}
