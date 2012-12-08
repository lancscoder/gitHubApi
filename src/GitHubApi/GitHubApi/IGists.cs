using GitHubApi.Entities;
using GitHubApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi
{
	public interface IGists
	{
		ListResponse<Gist> Public(int page = 1, int perPage = 100);
		Task<ListResponse<Gist>> PublicAsync(int page = 1, int perPage = 100);
	}
}
