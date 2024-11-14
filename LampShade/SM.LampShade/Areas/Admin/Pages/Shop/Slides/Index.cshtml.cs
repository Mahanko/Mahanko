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
    public class IndexModel : PageModel
    {
        public List<SlideViewModel> Slides { get; set; }
        private readonly ISlideApplication _slideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet()
        {
            Slides = _slideApplication.GetList();
        }

        public RedirectToPageResult OnPostRemove(long id)
        {
           _slideApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnPostRestore(long id)
        {
            _slideApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
