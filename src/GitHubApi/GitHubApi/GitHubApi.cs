using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi
{
	public partial class GitHubApi : IGitHubApi
	{
		private IGists _gists;

		public GitHubApi()
		{
			_gists = new Gists();
		}

		public IGists Gists
		{
			get { return _gists; }
		}

		public static IGitHubApi Current
		{
			get
			{
				return Settings.ApiProvider.GetCurrentApi();
			}
		}
	}
}
