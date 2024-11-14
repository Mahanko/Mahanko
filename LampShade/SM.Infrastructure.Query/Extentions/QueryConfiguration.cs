using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SM.Domain.ProductAgg;
using SM.Domain.ProductCategoryAgg;
using SM.Domain.ProductPictureAgg;
using SM.Domain.SlideAgg;
using SM.Infrastructure.EFCore.Repository;
using SM.Infrastructure.EFCore;
using SM.Infrastructure.Query.Query;
using SM.Infrastructure.Query.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.Query.Extentions
{
    public static class QueryConfiguration
    {
        public static void AddQueryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ISlideQuery, SlideQuery>();
        }
    }
}
