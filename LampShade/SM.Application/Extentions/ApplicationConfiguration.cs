using Microsoft.Extensions.DependencyInjection;
using SM.ApplicationContracts.ProductCategory;
using SM.ApplicationContracts.ProductPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.Extentions
{
    public static class ApplicationConfiguration
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddScoped<IProductPictureApplication, ProductPictureApplication>();
            services.AddScoped<IProductApplication, ProductApplication>();
        }
    }
}
