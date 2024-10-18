using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Application;
using SM.ApplicationContracts.Product;
using SM.ApplicationContracts.ProductCategory;

namespace SM.LampShade.Areas.Admin.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products { get; set; }
        public SelectList ProductCategories;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _categoryApplication;

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication categoryApplication)
        {
            _productApplication = productApplication;
            _categoryApplication = categoryApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_categoryApplication.GetProductCategories(),"Id","Name");
            Products = _productApplication.Search(searchModel);
        }

        public RedirectToPageResult OnPostInStock(long id)
        {
            _productApplication.InStock(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnPostNotInStock(long id)
        {
            _productApplication.NotInStock(id);
            return RedirectToPage("./Index");
        }
    }
}
