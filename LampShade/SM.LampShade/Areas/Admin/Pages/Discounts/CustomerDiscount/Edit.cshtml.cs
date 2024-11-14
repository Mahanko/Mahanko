using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Application;
using SM.ApplicationContracts.Product;
using SM.ApplicationContracts.ProductCategory;

namespace SM.LampShade.Areas.Admin.Pages.Discount.CustomerDiscount
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditCustomerDiscount command { get; set; }
        public SelectList Products;
        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;

        public EditModel(ICustomerDiscountApplication customerDiscountApplication, IProductApplication productApplication)
        {
            _customerDiscountApplication = customerDiscountApplication;
            _productApplication = productApplication;
        }

        public void OnGet(long id)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            command = _customerDiscountApplication.GetDetails(id);
        }
        public RedirectToPageResult OnPost() 
        {
            _customerDiscountApplication.Edit(command);
           
            return RedirectToPage("./Index");
        }
    }
}
