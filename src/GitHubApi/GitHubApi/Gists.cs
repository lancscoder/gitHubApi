using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GitHubApi.Extensions;

namespace GitHubApi
{
	// TODO : Gists and Issues....
	// TODO : Get the header
	// TODO : Include security if needed..
	public class Gist
	{
		public string Url { get; set; }
	}

	public class Gists : Base
	{
		private RestClient _client;

		public Gists()
		{
			_client = new RestClient(GitHubApi.Settings.ApiUrl);
		}

		public GitHubResponse<List<Gist>> Public(int page = 1, int perPage = 100)
		{
			var request = BuildPublicRequest(page, perPage);

			var response = Execute<List<Gist>>(request);

			return response;
		}

		// make this into a using.....
		// next, last, first, prev
		public async Task<GitHubResponse<List<Gist>>> PublicAsync(int page = 1, int perPage = 100)
		{
			var request = BuildPublicRequest(page, perPage);

			var response = await ExecuteAsync<List<Gist>>(request);

			return response;
		}

		private IRestRequest BuildPublicRequest(int page = 1, int perPage = 100)
		{
			return BuildRequest("gists/public", Method.GET,
				new Parameter() { Name = "page", Value = page, Type = ParameterType.GetOrPost },
				new Parameter() { Name = "per_page", Value = perPage, Type = ParameterType.GetOrPost });
		}

		//public string Single(string id)
		//{
		//	using (var webClients = new WebClient())
		//	{
		//		return webClients.DownloadString(string.Format(_PUBLIC_GIST_SINGLE_URI, id));
		//	}
		//}
		//
		//public async Task<string> SingleAsync(string id)
		//{
		//	using (var webClients = new WebClient())
		//	{
		//		return await webClients.DownloadStringTaskAsync(string.Format(_PUBLIC_GIST_SINGLE_URI, id));
		//	}
		//}

		// TODO : Move somewhere better
		private IRestRequest BuildRequest(string resource, Method method, params Parameter[] parameters)
		{
			var request = new RestRequest(resource, method);

			request.AddParameters(parameters);

			return request;
		}

		private GitHubResponse<T> Execute<T>(IRestRequest request) where T : class, new()
		{
			var response = _client.Execute<T>(request);

			var gitHubResponse = GitHubResponse<T>.GetResponse(response);

			return gitHubResponse;
		}

		private async Task<GitHubResponse<T>> ExecuteAsync<T>(IRestRequest request) where T : class, new()
		{
			var response = await _client.ExecuteAsync<T>(request);

			var gitHubResponse = GitHubResponse<T>.GetResponse(response);

			return gitHubResponse;
		}

		public void Dispose()
		{
			// Dispose???
			//_client.dis
			//throw new NotImplementedException();
		}
	}
}
