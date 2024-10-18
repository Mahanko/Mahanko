using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SM.ApplicationContracts.ProductCategory;

namespace SM.LampShade.Areas.Admin.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel SearchModel;
        public List<ProductCategoryViewModel> ProductCategories { get; set; }
        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
          ProductCategories=  _productCategoryApplication.Search(searchModel);
        }

        public RedirectToPageResult OnPostDelete(long id)
        {
            _productCategoryApplication.Delete(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnPostRestore(long id)
        {
            _productCategoryApplication.Restore(id);
            return RedirectToPage("./Index");
        }

    }
}
