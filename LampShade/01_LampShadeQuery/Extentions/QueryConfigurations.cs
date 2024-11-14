using _01_LampShadeQuery.Contracts.ProductCategory;
using _01_LampShadeQuery.Contracts.Slides;
using _01_LampShadeQuery.Query;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Extentions
{
    public static class QueryConfigurations
    {
        public static void AddQueryConfigration(this IServiceCollection services)
        {
            services.AddScoped<ISlideQuery,SlideQuery>();
            services.AddScoped<IProductCategoryQuery,ProductCategoryQuery>();
        }
    }
}
