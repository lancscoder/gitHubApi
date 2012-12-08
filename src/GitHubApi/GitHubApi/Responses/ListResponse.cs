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
	public class ListResponse<T> : Response<T> where T : class
	{
		public new List<T> Result { get; private set; }

		internal static ListResponse<T> GetResponse(IRestResponse<List<T>> restResponse)
		{
			var response = new ListResponse<T>();

			response.SetProperties(restResponse);

			// TOOD : Set next page etc here.

			response.Result = restResponse.Data;

			return response;
		}
	}
}
