using Asp.Versioning;
using Microsoft.Extensions.Options;
using MiniInventory.Core.Domain;
using MiniInventory.Core.EFServices;
using MiniInventory.Core.Services;
using StudentsManagementApi.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MiniInventory.API.Utils;
public static class CommonConfigurationServices
{
    public static IServiceCollection CommonConfigurationService(this IServiceCollection services)
    {

        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<DataSeeder>();

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddSwaggerGen(options =>
        {
            // Add a custom operation filter which sets default values
            options.OperationFilter<SwaggerDefaultValues>();
        });



        services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new ApiVersion(2, 0);
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;
            opt.ApiVersionReader = new UrlSegmentApiVersionReader();
         });


        services
            .AddApiVersioning()
            .AddApiExplorer(options =>
            {

                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      
        services.AddScoped<IProductService>(sp =>
        {
            var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
            var request = httpContextAccessor.HttpContext.Request;
            var path = request.Path.Value;
            var segments = path.Split("/");
            var apiVersion = segments[2];

            if (apiVersion == "v1")
            {
                return sp.GetRequiredService<MiniInventory.Core.SQLServices.ProductService>();
            }
            else if (apiVersion == "v2")
            {
                return sp.GetRequiredService<ProductService>();
            }
            else
            {
                throw new InvalidOperationException("Unsupported API version");
            }
        });

        services.AddScoped<ITransactionService>(sp =>
        {
            var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
            var request = httpContextAccessor.HttpContext.Request;
            var path = request.Path.Value;
            var segments = path.Split("/");
            var apiVersion = segments[2];

            if (apiVersion == "v1")
            {
                return sp.GetRequiredService<MiniInventory.Core.SQLServices.TransactionService>();
            }
            else if (apiVersion == "v2")
            {
                return sp.GetRequiredService<TransactionService>();
            }
            else
            {
                throw new InvalidOperationException("Unsupported API version");
            }
        });

        services.AddScoped<IWarehouseService>(sp =>
        {
            var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
            var request = httpContextAccessor.HttpContext.Request;
            var path = request.Path.Value;
            var segments = path.Split("/");
            var apiVersion = segments[2];

            if (apiVersion == "v1")
            {
                return sp.GetRequiredService<MiniInventory.Core.SQLServices.WarehouseService>();
            }
            else if (apiVersion == "v2")
            {
                return sp.GetRequiredService<WarehouseService>();
            }
            else
            {
                throw new InvalidOperationException("Unsupported API version");
            }
        });



        return services;
    }
}