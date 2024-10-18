using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SM.ApplicationContracts.ProductCategory;
using SM.Domain.ProductCategoryAgg;

namespace SM.LampShade.Areas.Admin.Pages.Shop.ProductCategories
{
    public class CreateModel : PageModel
    {
        public CreateProductCategory command {  get; set; }
        public CreateProductCategory CreateProductCategory { get; set; }
        private readonly IProductCategoryApplication _productCategoryApplication;

        public CreateModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPostCreate(CreateProductCategory command)
        {
            if (ModelState.IsValid)
            {
                _productCategoryApplication.Create(command);
                return RedirectToPage("./Index");
            }
            return Page();
            
        }
    }
}
