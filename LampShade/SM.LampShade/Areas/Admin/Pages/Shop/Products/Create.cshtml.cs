using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SM.Application;
using SM.ApplicationContracts.Product;
using SM.ApplicationContracts.ProductCategory;

namespace SM.LampShade.Areas.Admin.Pages.Shop.Products
{
    public class CreateModel : PageModel
    {
        public CreateProduct command { get; set; }
        public SelectList ProductCategories;
        private readonly IProductCategoryApplication _categoryApplication;
        private readonly IProductApplication _productApplication;

        public CreateModel(IProductApplication productApplication, IProductCategoryApplication categoryApplication)
        {
            _productApplication = productApplication;
            _categoryApplication = categoryApplication;
        }
        public void OnGet()
        {
            ProductCategories = new SelectList(_categoryApplication.GetProductCategories(), "Id", "Name");
        }

        public IActionResult OnPost(CreateProduct command)
        {
            if (ModelState.IsValid)
            {
                _productApplication.Create(command);
                return RedirectToPage("./Index");
            }
            return Page();

        }
    }
}
