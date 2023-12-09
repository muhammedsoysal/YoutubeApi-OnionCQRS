﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using YoutubeApi.Application.Exceptions;

namespace YoutubeApi.Application;

public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly=Assembly.GetExecutingAssembly();

        services.AddTransient<ExceptionMiddleware>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

    }
}