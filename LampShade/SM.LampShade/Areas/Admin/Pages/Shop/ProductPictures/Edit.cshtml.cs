using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Application;
using SM.ApplicationContracts.Product;
using SM.ApplicationContracts.ProductCategory;
using SM.ApplicationContracts.ProductPicture;

namespace SM.LampShade.Areas.Admin.Pages.Shop.ProductPictures
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditProductPicture command { get; set; }
        public SelectList Products;
        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;

        public EditModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }

        public void OnGet(long id)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            command = _productPictureApplication.GetDetails(id);
        }
        public RedirectToPageResult OnPost() 
        {
            _productPictureApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
