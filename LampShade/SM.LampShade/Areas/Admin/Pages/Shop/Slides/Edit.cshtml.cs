using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Application;
using SM.ApplicationContracts.Product;
using SM.ApplicationContracts.ProductCategory;
using SM.ApplicationContracts.ProductPicture;
using SM.ApplicationContracts.Slide;

namespace SM.LampShade.Areas.Admin.Pages.Shop.Slides
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditSlide command { get; set; }
        private readonly ISlideApplication _slideApplication;

        public EditModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet(long id)
        {
           command = _slideApplication.GetDetails(id);
        }
        public RedirectToPageResult OnPost() 
        {
            _slideApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
