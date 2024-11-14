using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using SM.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EfCore.Repository
{
    public class CustomerDiscountRepository:RepositoryBase<long,CustomerDiscount>,ICustomerDiscountReposiroty
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _Shopcontext;

        public CustomerDiscountRepository(DiscountContext context, ShopContext shopcontext) : base(context)
        {
            _context = context;
            _Shopcontext = shopcontext;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
           return _context.CustomerDiscounts.Select(x=>new EditCustomerDiscount
           {
               Id=x.Id,
               ProductId=x.ProductId,
               DiscountRate=x.DiscountRate,
               EndDate=x.EndDate.ToString(),
               StartDay=x.StartDay.ToString(),
               Reason=x.Reason,
               
           }).FirstOrDefault(x=>x.Id==id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var product = _Shopcontext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.CustomerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                EndDate = x.EndDate.ToFarsi(),
                StartDay  = x.StartDay.ToFarsi(),
                StartDayGr = x.StartDay,
                EndDateGr = x.EndDate,
                ProductId=x.ProductId,
                Reason=x.Reason,
                CreationDate=x.CreationDate.ToFarsi()
            });
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (!string.IsNullOrWhiteSpace(searchModel.StartDay))
            {
                var startDate = DateTime.Now;
                query = query.Where(x => x.StartDayGr > searchModel.StartDay.ToGeorgianDateTime());
            }

            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                var EndDate = DateTime.Now;
                query = query.Where(x => x.EndDateGr < searchModel.EndDate.ToGeorgianDateTime());
            }
            var discount = query.OrderByDescending(x => x.Id).ToList();
            discount.ForEach(discount => discount.Product = product.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);
            return discount;
        }
    }
}
