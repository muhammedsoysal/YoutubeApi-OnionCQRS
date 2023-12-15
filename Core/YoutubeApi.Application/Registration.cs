using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using YoutubeApi.Application.Exceptions;
using FluentValidation;
using MediatR;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Behaviors;
using YoutubeApi.Application.Features.Products.Command.CreateProduct;
using YoutubeApi.Application.Features.Products.Rules;

namespace YoutubeApi.Application;

public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly=Assembly.GetExecutingAssembly();

        services.AddTransient<ExceptionMiddleware>();
        services.AddTransient<ProductRules>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

        services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

        services.AddValidatorsFromAssembly(assembly);
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(FluentValidationBehavior<,>));
    }

    private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection serviceCollection,Assembly assembly,Type type)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
	        serviceCollection.AddTransient(item);

        return serviceCollection;
    }
}