using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http.Authentication;

namespace YoutubeApi.Application.Features.Auth.Command.RefreshToken
{
	public class RefreshTokenCommandRequest : IRequest<RefreshTokenCommandResponse>
	{
		public string  AccessToken { get; set; }
		public string  RefreshToken { get; set; }
	}
}
