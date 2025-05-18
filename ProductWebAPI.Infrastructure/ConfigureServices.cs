using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductWebAPI.Core.Repository;
using ProductWebAPI.Infrastructure.Repository;

namespace ProductWebAPI.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "ProductDatabase.db");
        services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlite($"Data Source={dbPath}"));

        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        return services;
    }
}