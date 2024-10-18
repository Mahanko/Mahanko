using _0_Framework.Domain;
using SM.Domain.ProductCategoryAgg;
using SM.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public double UnitPrice { get; private set; }
        public string Code { get; private set; }
        public bool IsInStock { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory Category { get;private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public List<ProductPicture> ProductPictures { get; private set; }
        protected Product() {}

        public Product(string name, double unitPrice, string code, string shortDescription, string description, 
            string picture, string pictureAlt, string pictureTitle, long categoryId, 
            string slug, string keyWords, string metaDescription)
        {
            Name = name;
            UnitPrice = unitPrice;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            IsInStock = true;
        }
        public void Edit(string name, double unitPrice, string code, string shortDescription, string description,
             string picture, string pictureAlt, string pictureTitle, long categoryId,
             string slug, string keyWords, string metaDescription)
        {
            Name = name;
            UnitPrice = unitPrice;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
        }
        public void InStock()
        {
            IsInStock = true;
        }
        public void NotInStock()
        {
            IsInStock=false;
        }
    }
}
