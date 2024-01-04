using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Auth.Rules;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.Tokens;
using YoutubeApi.Application.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Command.RefreshToken
{
	public class RefreshTokenCommandHandler:BaseHandler,IRequestHandler<RefreshTokenCommandRequest,RefreshTokenCommandResponse>
	{
		private readonly UserManager<User> _userManager;
		private readonly ITokenService _tokenService;
		private readonly AuthRules _authRules;

		public RefreshTokenCommandHandler(UserManager<User> userManager,ITokenService tokenService,AuthRules authRules,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
		{
			_userManager = userManager;
			_tokenService = tokenService;
			_authRules = authRules;
		}
		public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
		{
			ClaimsPrincipal? principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
			string email = principal.FindFirstValue(ClaimTypes.Email);

			User? user = await _userManager.FindByEmailAsync(email);
			var roles = await _userManager.GetRolesAsync(user);

			if (user.RefreshTokenExpriyTime <= DateTime.Now)
				throw new System.Exception("");

			await _authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpriyTime);

			JwtSecurityToken newAccessToken = await _tokenService.CreateToken(user, roles);
			string newRefreshToken = _tokenService.GenerateRefreshToken();

			user.RefreshToken=newRefreshToken;
			await _userManager.UpdateAsync(user);

			return new()
			{
				AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
				RefreshToken = newRefreshToken,
			};
		}
	}
}
