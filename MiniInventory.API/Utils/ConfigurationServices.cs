
using Microsoft.EntityFrameworkCore;
using MiniInventory.Core.Domain;
using MiniInventory.Core.Services;
using MiniInventory.Infrastructure.Sql;
using System.Reflection;

namespace MiniInventory.API.Utils;
public static class ConfigurationServices
{
    public static IServiceCollection ConfigurationService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DbConnection");
        services.AddDbContext<MiniInventoryContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<DataSeeder>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<ITransactionTypeService, TransactionTypeService >();
        services.AddScoped<IWarehouseService, WarehouseService>();


        return services;
    }
}