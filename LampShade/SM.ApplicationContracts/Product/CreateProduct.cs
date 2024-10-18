using SM.ApplicationContracts.ProductCategory;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SM.ApplicationContracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = "نام نمیتواند خالی باشد")]
        [MaxLength(255,ErrorMessage = "نام نمیتواند بیشتر از 255 کاراکتر باشد")]
        public string Name { get; set; }
        [Required(ErrorMessage = "قیمت نمیتواند خالی باشد")]
        public double UnitPrice { get; set; }
        [Required(ErrorMessage = "کد نمیتواند خالی باشد")]
        [MaxLength(250, ErrorMessage = "کد نمیتواند بیشتر از 250 کاراکتر باشد")]
        [MinLength(1, ErrorMessage = "کد نمیتواند کمتر از 1 کاراکتر باشد")]
        public string Code { get; set; }
        [Required(ErrorMessage = "توضیح کوتاه نمیتواند خالی باشد")]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "عکس نمیتواند خالی باشد")]
        [MaxLength(4000,ErrorMessage = "عکس نمیتواند بیشتر از 4000 کاراکتر باشد")]
        public string Picture { get; set; }
        [Required(ErrorMessage = "توضیح عکس نمیتواند خالی باشد")]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = "تایتل عکس نمیتواند خالی باشد")]

        public string PictureTitle { get; set; }
        [Required(ErrorMessage = "گروه محصول نمیتواند خالی باشد")]

        public long CategoryId { get; set; }
        [Required(ErrorMessage = "اسلاگ نمیتواند خالی باشد")]

        public string Slug { get; set; }
        [Required(ErrorMessage = "کلمات کلیدی نمیتواند خالی باشد")]

        public string KeyWords { get; set; }
        [Required(ErrorMessage = "توضیحات متا نمیتواند خالی باشد")]

        public string MetaDescription { get; set; }
    }
}
