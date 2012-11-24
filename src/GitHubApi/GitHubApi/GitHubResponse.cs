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
	// TODO : Have GitHubListResponse?
	public class GitHubResponse<T> where T : class
	{
		public HttpStatusCode StatusCode { get; private set; }
		public string ErrorMessage { get; private set; }

		public int RateLimit { get; private set; }
		public int RateRemaining { get; private set; }

		public T Result { get; private set; }

		// Make this better for generic type.
		internal static GitHubResponse<T> GetResponse(IRestResponse<T> restResponse)
		{
			var response =  new GitHubResponse<T>();

			response.StatusCode = restResponse.StatusCode;

			var header = restResponse.Headers;

			response.RateLimit = restResponse.Headers.GetValue<int>("X-RateLimit-Limit");
			response.RateRemaining = restResponse.Headers.GetValue<int>("X-RateLimit-Remaining");
			
			// Serialize this in javascript
			response.Result = restResponse.Data;// (T)Convert.ChangeType(restResponse.Content, typeof(T));

			return response;
		}
	}
}
