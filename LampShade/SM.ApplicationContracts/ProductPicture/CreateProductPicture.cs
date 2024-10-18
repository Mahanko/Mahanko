using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.ApplicationContracts.ProductPicture
{
    public class CreateProductPicture
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(4000, ErrorMessage = "عکس نمیتواند بیشتر از 4000 کاراکتر باشد")]
        public string Picture { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MinLength(5,ErrorMessage = "تایتل نمیتواند زیر 5 کاراکتر باشد")]
        public string PictureTitle { get; set; }
    }
}
