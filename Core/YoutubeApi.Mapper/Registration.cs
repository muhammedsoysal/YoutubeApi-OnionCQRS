﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using YoutubeApi.Application.Interfaces.AutoMapper;

namespace YoutubeApi.Mapper;

public static class Registration
{
    public static void AddCustomMapper(this IServiceCollection services)
    {
        services.AddSingleton<IMapper, AutoMapper.Mapper>();
    }
}