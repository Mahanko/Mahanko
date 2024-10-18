using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SM.Application;
using SM.ApplicationContracts.Product;
using SM.ApplicationContracts.ProductCategory;
using SM.ApplicationContracts.ProductPicture;

namespace SM.LampShade.Areas.Admin.Pages.Shop.ProductPictures
{
    public class CreateModel : PageModel
    {
        public CreateProductPicture command { get; set; }
        public SelectList Products;
        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _productPictureApplication;

        public CreateModel(IProductApplication productApplication, IProductPictureApplication productPictureApplication)
        {
            _productApplication = productApplication;
            _productPictureApplication = productPictureApplication;
        }

        public void OnGet()
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        }

        public IActionResult OnPost(CreateProductPicture command)
        {
            if (ModelState.IsValid)
            {
               _productPictureApplication.Create(command);
                return RedirectToPage("./Index");
            }
            return Page();

        }
    }
}
