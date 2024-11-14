using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using SM.Domain.ProductAgg;
using SM.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EfCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly ShopContext _shopContext;
        private readonly DiscountContext _context;

        public ColleagueDiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _context.ColleagueDiscounts.Select(x => new EditColleagueDiscount
            {
                Id=x.Id,
                DiscountRate=x.DiscountRate,
                ProductId=x.ProductId,
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new {x.Id,x.Name }).ToList();
            var query = _context.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel
            {
                Id=x.Id,
                CreationDate=x.CreationDate.ToFarsi(),
                DiscountRate=x.DiscountRate,
                IsDeleted=x.IsDeleted,
                ProductId=x.ProductId
            });
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            var discount = query.OrderByDescending(x=>x.Id).ToList();
            discount.ForEach(discount => discount.Product = products.FirstOrDefault(x=>x.Id==discount.ProductId)?.Name);
            return discount;
        }
    }
}
