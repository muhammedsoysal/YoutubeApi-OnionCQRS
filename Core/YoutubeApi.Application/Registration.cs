using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using YoutubeApi.Application.Exceptions;
using FluentValidation;
using MediatR;
using YoutubeApi.Application.Behaviors;
using YoutubeApi.Application.Features.Products.Command.CreateProduct;

namespace YoutubeApi.Application;

public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly=Assembly.GetExecutingAssembly();

        services.AddTransient<ExceptionMiddleware>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

        services.AddValidatorsFromAssembly(assembly);
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(FluentValidationBehavior<,>));
    }
}