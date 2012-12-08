using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GitHubApi.Extensions;

namespace GitHubApi.Responses
{
	public class Response<T> where T : class
	{
		public HttpStatusCode StatusCode { get; internal set; }
		public string ErrorMessage { get; internal set; }

		public int RateLimit { get; internal set; }
		public int RateRemaining { get; internal set; }

		public T Result { get; private set; }

		internal static Response<T> GetResponse(IRestResponse<T> restResponse)
		{
			var response =  new Response<T>();

			response.SetProperties(restResponse);

			response.Result = restResponse.Data;

			return response;
		}

		internal void SetProperties(IRestResponse restResponse)
		{
			StatusCode = restResponse.StatusCode;

			var header = restResponse.Headers;

			RateLimit = restResponse.Headers.GetValue<int>("X-RateLimit-Limit");
			RateRemaining = restResponse.Headers.GetValue<int>("X-RateLimit-Remaining");
		}

	}
}
