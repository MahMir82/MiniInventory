
using Microsoft.EntityFrameworkCore;
using MiniInventory.Core.Domain;
using MiniInventory.Core.EFServices;
using MiniInventory.Infrastructure.EF;

namespace MiniInventory.API.Utils;
public static class EFConfigurationServices
{
    public static IServiceCollection EFConfigurationService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DbConnection");
        services.AddDbContext<MiniInventoryContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<ITransactionTypeService, TransactionTypeService >();
        services.AddScoped<IWarehouseService, WarehouseService>();

        return services;
    }
}