using _0_Framework.Application;
using SM.ApplicationContracts.ProductPicture;
using SM.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SM.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var opration = new OperationResult();
            if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);
            var productPicture = new ProductPicture(command.ProductId, command.Picture,command.PictureAlt,command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
             return opration.Successful();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var opration = new OperationResult();
            var productPicture = _productPictureRepository.Get(command.Id);
            if(productPicture==null)
                return opration.Failed(ApplicationMessages.RecordNotFound);
            if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId && x.Id == command.Id))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);
            productPicture.Edit(command.ProductId,command.Picture,command.PictureAlt,command.PictureTitle);
            _productPictureRepository.SaveChanges();
            return opration.Successful();
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var opration = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);
            productPicture.Remove();
            _productPictureRepository.SaveChanges();
            return opration.Successful();
        }
        public OperationResult Restore(long id)
        {
            var opration = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);
            productPicture.Restore();
            _productPictureRepository.SaveChanges();
            return opration.Successful();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
           return _productPictureRepository.Search(searchModel);
        }
    }
}
