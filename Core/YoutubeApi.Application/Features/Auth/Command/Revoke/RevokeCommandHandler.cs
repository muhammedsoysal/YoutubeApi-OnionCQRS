using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Auth.Rules;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Command.Revoke
{
	public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
	{
		private readonly UserManager<User> _userManager;
		private readonly AuthRules _authRules;

		public RevokeCommandHandler(UserManager<User> userManager, AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
		{
			_userManager = userManager;
			_authRules = authRules;
		}

		public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
		{
			User user = await _userManager.FindByEmailAsync(request.Email);
			await _authRules.EmailAddressShouldBeValid(user);

			user.RefreshToken = null;
			await _userManager.UpdateAsync(user);

			return Unit.Value;
		}
	}
}
