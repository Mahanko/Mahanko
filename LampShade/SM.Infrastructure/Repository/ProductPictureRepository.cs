using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SM.ApplicationContracts.ProductPicture;
using SM.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.EFCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext context) : base(context) 
        {
            _context = context;
        }

        public EditProductPicture GetDetails(long id)
        {
            return _context.ProductPictures.Select(x => new EditProductPicture
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                ProductId = x.ProductId,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = _context.ProductPictures.Include(x=>x.Products).Select(x => new ProductPictureViewModel
            {
                Id= x.Id,
                ProductId= x.ProductId,
                Picture = x.Picture,
                IsDeleted = x.IsDeleted,
                CreationDate =x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Products=x.Products.Name,
            });
            if (searchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
