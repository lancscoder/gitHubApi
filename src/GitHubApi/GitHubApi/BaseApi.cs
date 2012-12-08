using GitHubApi.Extensions;
using GitHubApi.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi
{
	public abstract class BaseApi
	{
		internal RestClient _client;

		internal IRestRequest BuildRequest(string resource, Method method, params Parameter[] parameters)
		{
			var request = new RestRequest(resource, method);

			request.AddParameters(parameters);

			return request;
		}

		internal Response<T> Execute<T>(IRestRequest request) where T : class, new()
		{
			var response = _client.Execute<T>(request);

			var gitHubResponse = Response<T>.GetResponse(response);

			return gitHubResponse;
		}

		internal async Task<Response<T>> ExecuteAsync<T>(IRestRequest request) where T : class, new()
		{
			var response = await _client.ExecuteAsync<T>(request);

			var gitHubResponse = Response<T>.GetResponse(response);

			return gitHubResponse;
		}

		internal ListResponse<T> ExecuteList<T>(IRestRequest request) where T : class, new()
		{
			var response = _client.Execute<List<T>>(request);

			var gitHubResponse = ListResponse<T>.GetResponse(response);

			return gitHubResponse;
		}

		internal async Task<ListResponse<T>> ExecuteListAsync<T>(IRestRequest request) where T : class, new()
		{
			var response = await _client.ExecuteAsync<List<T>>(request);

			var gitHubResponse = ListResponse<T>.GetResponse(response);

			return gitHubResponse;
		}
	}
}
