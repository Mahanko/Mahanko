using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SM.Application;
using SM.ApplicationContracts.Product;
using SM.ApplicationContracts.ProductCategory;
using SM.ApplicationContracts.ProductPicture;
using SM.ApplicationContracts.Slide;

namespace SM.LampShade.Areas.Admin.Pages.Shop.Slides
{
    public class CreateModel : PageModel
    {
        public CreateSlide command { get; set; }
        private readonly ISlideApplication _slideApplication;

        public CreateModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet()
        {
          
        }

        public IActionResult OnPost(CreateSlide command)
        {
            if (ModelState.IsValid)
            {
               _slideApplication.Create(command);
                return RedirectToPage("./Index");
            }
            return Page();

        }
    }
}
