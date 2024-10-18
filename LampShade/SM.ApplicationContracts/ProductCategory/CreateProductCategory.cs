using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.ApplicationContracts.ProductCategory
{
    public class CreateProductCategory
    {
        //................................................
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DebuggerDisplay("نام")]
        public string Name { get; set; }
        //................................................
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(4000, ErrorMessage = "عکس نمیتواند بیشتر از 4000 کاراکتر باشد")]
        public string Picture { get; set; }
        //................................................
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }
        //................................................
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }
        //................................................
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get; set; }
        //................................................
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }
        //................................................
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MinLength(100, ErrorMessage = "توضیحات نمیتواند کمتر از 100 کاراکتر باشد")]
        public string Description { get; set; }
        //................................................
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        //................................................
    }
}
