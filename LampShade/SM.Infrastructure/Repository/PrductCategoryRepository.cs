using _0_Framework.Infrastructure;
using SM.ApplicationContracts.ProductCategory;
using SM.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.EFCore.Repository
{
    public class PrductCategoryRepository : RepositoryBase<long,ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public PrductCategoryRepository(ShopContext context):base(context) 
        {
            _context = context;
        }
        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(x => new EditProductCategory
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,        
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,

            }).FirstOrDefault(X => X.Id == id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
           return _context.ProductCategories.Select(x=>new ProductCategoryViewModel
           {
                    Id=x.Id,
                    Name = x.Name,
           }).ToList();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                IsDeleted=x.IsDeleted,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
            });
            if (!string.IsNullOrWhiteSpace(searchModel.name))
                query = query.Where(x => x.Name.Contains(searchModel.name));
            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
