using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.ApplicationContracts.Slide
{
    public class CreateSlide
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(4000,ErrorMessage ="عکس نمیتواند بیشتر از 4000 کاراکتر باشد")]
        public string Picture { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "توضیح عکس نمیتواند بیشتر از 500 کاراکتر باشد")]

        public string PictureAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تایتل عکس نمیتواند بیشتر از 500 کاراکتر باشد")]

        public string PictureTittle { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(255, ErrorMessage = "سرتیتر نمیتواند بیشتر از 255 کاراکتر باشد")]

        public string Heading { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(255, ErrorMessage = "عنوان نمیتواند بیشتر از 255 کاراکتر باشد")]

        public string Title { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(255, ErrorMessage = "متن نمیتواند بیشتر از 255 کاراکتر باشد")]

        public string Text { get;  set; }
        [MaxLength(50, ErrorMessage = "متن دکمه نمیتواند بیشتر از 50 کاراکتر باشد")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string BtnText { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Link { get; set; }
    }
}
