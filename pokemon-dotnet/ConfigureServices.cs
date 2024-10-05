using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Persistence;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Core.Common.Interfaces;
using Pokemon.pokemon_dotnet.Services;

namespace pokemon_dotnet
{
    public static class ConfigureServices
    {
         public static IServiceCollection AddAPIServices(this IServiceCollection services)
    {
        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();
  


        services.Configure<ApiBehaviorOptions>(options =>
     options.SuppressModelStateInvalidFilter = true);

        return services;
    }
    }
}