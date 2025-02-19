﻿using _0_Framework.Application;
using SM.ApplicationContracts.Product;
using SM.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SM.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var product = new Product(command.Name, command.UnitPrice, command.Code, command.ShortDescription, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.CategoryId, command.Slug, command.KeyWords, command.MetaDescription);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Successful();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(command.Id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            product.Edit(command.Name, command.UnitPrice, command.Code, command.ShortDescription, command.Description, command.Picture,
            command.PictureAlt, command.PictureTitle, command.CategoryId, command.Slug, command.KeyWords, command.MetaDescription);
            _productRepository.SaveChanges();
            return operation.Successful();
        }
        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public OperationResult InStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            product.InStock();

            _productRepository.SaveChanges();
            return operation.Successful();
        }
        public OperationResult NotInStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            product.NotInStock();

            _productRepository.SaveChanges();
            return operation.Successful();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }

    }
}
