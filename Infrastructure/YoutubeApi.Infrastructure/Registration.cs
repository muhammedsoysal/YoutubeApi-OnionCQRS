using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using YoutubeApi.Infrastructure.Tokens;

namespace YoutubeApi.Infrastructure
{
	public static class Registration
	{
		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<TokenSettings>(configuration.GetSection("JWT"));
		}
	}
}
