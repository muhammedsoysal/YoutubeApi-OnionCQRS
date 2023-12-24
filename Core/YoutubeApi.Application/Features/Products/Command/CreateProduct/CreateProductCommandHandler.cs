using MediatR;
using Microsoft.AspNetCore.Http;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Products.Rules;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandHandler : BaseHandler,IRequestHandler<CreateProductCommandRequest, Unit>
{
	private readonly ProductRules _productRules;

	public CreateProductCommandHandler( ProductRules productRules,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
	{
		_productRules = productRules;
	}

	public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
	{
		IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();


		//if (products.Any(x => x.Title == request.Title))
		//	throw new Exception("Aynı başlıkta ürün olamaz.");

		await _productRules.ProductTitleMustNotBeSame(products, request.Title);
		
		Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

		await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);
		if (await _unitOfWork.SaveAsync() > 0)
		{
			foreach (var categoryId in request.CategoryIds)
				await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
				{
					ProductId = product.Id,
					CategoryId = categoryId
				});

			await _unitOfWork.SaveAsync();
		}
		return Unit.Value;
	}
}