using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Command.RevokeAll
{
	public class RevokeAllCommandHandler : BaseHandler, IRequestHandler<RevokeAllCommandRequest, Unit>
	{
		private readonly UserManager<User> _userManager;

		public RevokeAllCommandHandler(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
		{
			_userManager = userManager;
		}

		public async Task<Unit> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
		{
			List<User> users = await _userManager.Users.ToListAsync(cancellationToken);
			foreach (User user in users)
			{
				user.RefreshToken = null;
				await _userManager.UpdateAsync(user);
			}

			return Unit.Value;
		}
	}
}
