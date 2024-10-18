using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Application;
using SM.ApplicationContracts.Product;
using SM.ApplicationContracts.ProductCategory;
using SM.ApplicationContracts.ProductPicture;

namespace SM.LampShade.Areas.Admin.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
        public ProductPictureSearchModel SearchModel;
        public List<ProductPictureViewModel> ProductPictures { get; set; }
        public SelectList Products;
        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _PictureApplication;

        public IndexModel(IProductApplication productApplication, IProductPictureApplication pictureApplication)
        {
            _productApplication = productApplication;
            _PictureApplication = pictureApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(),"Id","Name");
            ProductPictures = _PictureApplication.Search(searchModel);
        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            _PictureApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnPostRestore(long id)
        {
            _PictureApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
