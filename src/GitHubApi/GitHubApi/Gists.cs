using GitHubApi.Entities;
using GitHubApi.Responses;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace GitHubApi
{
	public class Gists : BaseApi, IGists
	{
		public Gists()
		{
			_client = new RestClient(GitHubApi.Settings.ApiUrl);
		}

		public Response<Gist> Single(string id)
		{
			var request = BuildSingleRequest(id);

			var resposnse = Execute<Gist>(request);

			return resposnse;
		}

		public async Task<Response<Gist>> SingleAsync(string id)
		{
			var request = BuildSingleRequest(id);

			var resposnse = await ExecuteAsync<Gist>(request);

			return resposnse;
		}

		public ListResponse<Gist> Public(int page = 1, int perPage = 100)
		{
			var request = BuildPublicRequest(page, perPage);

			var response = ExecuteList<Gist>(request);

			return response;
		}

		// make this into a using.....
		// next, last, first, prev
		public async Task<ListResponse<Gist>> PublicAsync(int page = 1, int perPage = 100)
		{
			var request = BuildPublicRequest(page, perPage);

			var response = await ExecuteListAsync<Gist>(request);

			return response;
		}

		private IRestRequest BuildSingleRequest(string id)
		{
			return BuildRequest(String.Format("gists/{0}", id), Method.GET);
		}

		private IRestRequest BuildPublicRequest(int page = 1, int perPage = 100)
		{
			return BuildRequest("gists/public", Method.GET,
				new Parameter() { Name = "page", Value = page, Type = ParameterType.GetOrPost },
				new Parameter() { Name = "per_page", Value = perPage, Type = ParameterType.GetOrPost });
		}
	}
}
