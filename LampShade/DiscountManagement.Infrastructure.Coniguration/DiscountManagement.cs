using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.Extensions.DependencyInjection;
using DiscountManagement.Application;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EfCore.Repository;
using DiscountManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SM.Infrastructure.EFCore;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;

namespace DiscountManagement.Infrastructure.Coniguration
{
    public class DiscountManagement
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            services.AddTransient<ICustomerDiscountReposiroty, CustomerDiscountRepository>();
            services.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();
            services.AddTransient<IColleagueDiscountRepository, ColleagueDiscountRepository>();
            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(configuration.GetConnectionString("ShopDB")));

        }
    }
}
