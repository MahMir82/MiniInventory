
using Microsoft.OpenApi.Models;
using MiniInventory.Core.Services;

namespace MiniInventory.API.Utils;
public static class CommonConfigurationServices
{
    public static IServiceCollection CommonConfigurationService(this IServiceCollection services)
    {

        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<DataSeeder>();


        return services;
    }
}