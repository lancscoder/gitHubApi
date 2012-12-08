using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi
{
	public partial class GitHubApi
	{
		// TODO : This needs somewhere better 
		public enum Scope
		{
			// TODO : Check bitwise operator
			NoScope = 0, // public read-only access (includes public user profile info, public repo info, and gists).
			User = 1 >> 0, // Read/write access to profile info only.
			PublicRepo = 1 >> 1, // Read/write access to public repos and organizations.
			Repo = 1 >> 2, // Read/write access to public and private repos and organizations.
			RepoStatus = 1 >> 3, // Read/write access to public and private repo statuses. Does not include access to code - use repo for that.
			DeleteRepo = 1 >> 4, // Delete access to adminable repositories.
			Notifications = 1 >> 5, // Read access to a user’s notifications. repo is accepted too.
			Gist = 1 >> 6,  // write access to gists.
		}

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

			public static IApiProvider ApiProvider { get; set; }

			public static void Initialize()
			{
				ApiProvider = new ApiProvider();
			}
		}
	}
}
