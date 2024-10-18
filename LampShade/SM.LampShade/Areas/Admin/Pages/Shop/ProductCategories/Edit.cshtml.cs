using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SM.ApplicationContracts.ProductCategory;

namespace SM.LampShade.Areas.Admin.Pages.Shop.ProductCategories
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditProductCategory EditCategory { get; set; }
        private readonly IProductCategoryApplication _productCategoryApplication;

        public EditModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(long id)
        {
            EditCategory = _productCategoryApplication.GetDetails(id);
        }
        public RedirectToPageResult OnPostEdit()
        {
            _productCategoryApplication.Edit(EditCategory);
            return RedirectToPage("./Index");
        }
    }
}
