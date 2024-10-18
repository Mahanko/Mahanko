using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Application;
using SM.ApplicationContracts.Product;
using SM.ApplicationContracts.ProductCategory;

namespace SM.LampShade.Areas.Admin.Pages.Shop.Products
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditProduct command { get; set; }
        public SelectList ProductCategories;
        private readonly IProductCategoryApplication _categoryApplication;
        private readonly IProductApplication _productApplication;

        public EditModel( IProductCategoryApplication categoryApplication, IProductApplication productApplication)
        {
            _categoryApplication = categoryApplication;
            _productApplication = productApplication;
        }

        public void OnGet(long id)
        {
            ProductCategories = new SelectList(_categoryApplication.GetProductCategories(), "Id", "Name");
            command = _productApplication.GetDetails(id);
        }
        public RedirectToPageResult OnPost() 
        {
            var i = command.Id;
            _productApplication.Edit(command);
           
            return RedirectToPage("./Index");
        }
    }
}
