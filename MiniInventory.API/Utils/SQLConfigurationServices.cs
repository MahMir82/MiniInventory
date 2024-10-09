
using Microsoft.EntityFrameworkCore;
using MiniInventory.Core.Domain;
using MiniInventory.Core.SQLServices;
using MiniInventory.Infrastructure.Sql;

namespace MiniInventory.API.Utils;
public static class SQLConfigurationServices
{
    public static IServiceCollection SQLConfigurationService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DbConnection");
        services.AddDbContext<MiniInventoryContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<ProductService>();
        services.AddScoped<TransactionService>();
        services.AddScoped<WarehouseService>();
        services.AddScoped<ITransactionTypeService, TransactionTypeService>();

        // services.AddScoped<IProductService, ProductService>();
        //services.AddScoped<ITransactionService, TransactionService>();
        //services.AddScoped<ITransactionTypeService, TransactionTypeService >();
        //services.AddScoped<IWarehouseService, WarehouseService>();

        return services;
    }
}