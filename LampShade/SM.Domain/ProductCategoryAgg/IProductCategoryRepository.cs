using _0_Framework.Domain;
using SM.ApplicationContracts.ProductCategory;
using SM.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository :IRepository<long,ProductCategory>
    {
        List<ProductCategoryViewModel> GetProductCategories();
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}
