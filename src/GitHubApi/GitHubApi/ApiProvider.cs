using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi
{
	public class ApiProvider : IApiProvider
	{
		private IGitHubApi _api;

		public ApiProvider()
		{
			_api = new GitHubApi();
		}

		public IGitHubApi GetCurrentApi()
		{
			return _api;
		}
	}
}
