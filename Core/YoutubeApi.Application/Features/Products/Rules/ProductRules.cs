using System.Net;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Products.Exceptions;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Products.Rules
{
	public class ProductRules : BaseRules
	{
		public Task ProductTitleMustNotBeSame(IList<Product> products,string requestTitle)
		{
			if (products.Any(x=>x.Title==requestTitle)) throw new ProtocolViolationException();
			return Task.CompletedTask;
		}
	}
}