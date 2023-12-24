using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.UnitOfWorks;

namespace YoutubeApi.Application.Bases
{
	public class BaseHandler
	{
		public readonly IMapper _mapper;
		public readonly IUnitOfWork _unitOfWork;
		public readonly IHttpContextAccessor _httpContextAccessor;
		public readonly string userId;

		public BaseHandler( IMapper mapper,IUnitOfWork unitOfWork,IHttpContextAccessor httpContextAccessor)
		{
			this._mapper = mapper;
			this._unitOfWork = unitOfWork;
			this._httpContextAccessor = httpContextAccessor;
			userId = (_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
		}
	}
}
