using _0_Framework.Application;
using SM.ApplicationContracts.ProductCategory;
using SM.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var opration = new OperationResult();
            if (_productCategoryRepository.Exists(x => x.Name == command.Name))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);
            var ProductCategory = new ProductCategory(command.Name, command.Description, command.Picture, command.PictureTitle,
                command.PictureTitle, command.KeyWords, command.MetaDescription, command.Slug);
            _productCategoryRepository.Create(ProductCategory);
            _productCategoryRepository.SaveChanges();
            return opration.Successful();

        }

        public void Delete(long id)
        {
            var category = _productCategoryRepository.Get(id);
            category.Delete();
            _productCategoryRepository.SaveChanges();
            
        }
        public void Restore(long id)
        {
            var category = _productCategoryRepository.Get(id);
            category.Restore();
            _productCategoryRepository.SaveChanges();
        }
        public OperationResult Edit(EditProductCategory command)
        {
            var opration = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);
            if (productCategory == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);
            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);
            productCategory.Edit(command.Name, command.Description, command.Picture, command.PictureAlt, command.PictureTitle,
               command.KeyWords, command.MetaDescription, command.Slug);
            _productCategoryRepository.SaveChanges();
            return opration.Successful();
        }

        public EditProductCategory GetDetails(long id)
        {
          return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _productCategoryRepository.GetProductCategories();
        }
    }
}
