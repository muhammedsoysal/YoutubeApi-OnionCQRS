using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApi.Application.Features.Auth.Command.Login
{
	public class LoginCommandRequest : IRequest<LoginCommandResponse>
	{
		[DefaultValue("info@muhammedsoysal.software")]
		public string email { get; set; }
		[DefaultValue("123456")]
		public string password { get; set; }
	}
}
