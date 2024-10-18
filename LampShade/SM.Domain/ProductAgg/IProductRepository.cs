using _0_Framework.Domain;
using SM.ApplicationContracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.ProductAgg
{
    public interface IProductRepository: IRepository<long,Product>
    {
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        EditProduct GetDetails(long id);
        List<ProductViewModel> GetProducts();
    }
}
