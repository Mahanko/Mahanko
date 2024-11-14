using DiscountManagement.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SM.Domain.ProductAgg;
using SM.Domain.ProductCategoryAgg;
using SM.Domain.ProductPictureAgg;
using SM.Domain.SlideAgg;
using SM.Infrastructure.EFCore.Repository;
namespace SM.Infrastructure.EFCore.Extentions;

public static class InfrastructureConfiguration
{
    public static void AddInfrastructureConfiguration(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped<IProductCategoryRepository, PrductCategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISlideRepository, SlideRepository>();
        services.AddScoped<IProductPictureRepository, ProductPictureRepository>();
        services.AddDbContext<ShopContext>(x=>x.UseSqlServer(configuration.GetConnectionString("ShopDB")));
    }
}
