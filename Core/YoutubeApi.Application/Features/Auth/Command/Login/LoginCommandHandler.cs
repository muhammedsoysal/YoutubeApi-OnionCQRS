using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Auth.Rules;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.Tokens;
using YoutubeApi.Application.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Command.Login
{
	public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
	{
		private readonly UserManager<User> _userManager;
		private readonly ITokenService _tokenService;
		private readonly IConfiguration _configuration;
		private readonly AuthRules _authRules;

		public LoginCommandHandler(UserManager<User> userManager, ITokenService tokenService, IConfiguration configuration,  AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
		{
			this._userManager = userManager;
			this._tokenService = tokenService;
			this._configuration = configuration;
			this._authRules = authRules;
		}

		public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
		{
			User user = await _userManager.FindByEmailAsync(request.email);
			bool checkPassword = await _userManager.CheckPasswordAsync(user, request.password);

			await _authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

			IList<string> roles = await _userManager.GetRolesAsync(user);

			JwtSecurityToken token = await _tokenService.CreateToken(user, roles);
			string refreshToken = _tokenService.GenerateRefreshToken();

			_ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

			user.RefreshToken = refreshToken;
			user.RefreshTokenExpriyTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

			await _userManager.UpdateAsync(user);
			await _userManager.UpdateSecurityStampAsync(user);

			string _token = new JwtSecurityTokenHandler().WriteToken(token);

			await _userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

			return new()
			{
				Token = _token,
				RefreshToken = refreshToken,
				Expiration = token.ValidTo
			};

		}
	}
}
