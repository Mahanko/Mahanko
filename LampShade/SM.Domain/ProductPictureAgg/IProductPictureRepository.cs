using _0_Framework.Domain;
using SM.ApplicationContracts.ProductPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<long,ProductPicture>
    {
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
