using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Extensions
{
	public static class RestSharpExtensions
	{
		private static Task<T> SelectAsync<T>(this RestClient client, IRestRequest request, Func<IRestResponse, T> selector)
		{
			var tcs = new TaskCompletionSource<T>();
			var loginResponse = client.ExecuteAsync(request, r =>
			{
				if (r.ErrorException == null)
				{
					tcs.SetResult(selector(r));
				}
				else
				{
					tcs.SetException(r.ErrorException);
				}
			});
		
			return tcs.Task;
		}

		private static Task<T> SelectAsync<T, U>(this RestClient client, IRestRequest request, Func<IRestResponse<U>, T> selector) where U : class, new()
		{
			var tcs = new TaskCompletionSource<T>();
			var loginResponse = client.ExecuteAsync<U>(request, r =>
			{
				if (r.ErrorException == null)
				{
					tcs.SetResult(selector(r));
				}
				else
				{
					tcs.SetException(r.ErrorException);
				}
			});

			return tcs.Task;
		}

		public static Task<IRestResponse> ExecuteAsync(this RestClient client, IRestRequest request)
		{
			return client.SelectAsync(request, r => r);
		}
	
		public static Task<IRestResponse<T>> ExecuteAsync<T>(this RestClient client, IRestRequest request) where T : class, new()
		{
			return client.SelectAsync<IRestResponse<T>, T>(request, r => r);
		}

		public static void AddParameters(this RestRequest request, Parameter[] parameters)
		{
			foreach (var parameter in parameters)
			{
				request.AddParameter(parameter);
			}
		}

		public static T GetValue<T>(this IList<Parameter> header, string name, T defaultValue = default(T))
		{
			var parameter = header.FirstOrDefault(h => h.Name.Equals(name));

			if (parameter == null) 
			{
				return defaultValue;
			}

			if (parameter.Value is T)
			{
				return (T)parameter.Value;
			}

			try
			{
				return (T)Convert.ChangeType(parameter.Value, typeof(T));
			}
			catch (InvalidCastException)
			{
				return default(T);
			}
		}
	}
}
