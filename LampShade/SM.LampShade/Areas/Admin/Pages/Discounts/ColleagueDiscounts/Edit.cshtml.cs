using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Application;
using SM.ApplicationContracts.Product;
using SM.ApplicationContracts.ProductCategory;

namespace SM.LampShade.Areas.Admin.Pages.Discount.ColleagueDiscounts
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditColleagueDiscount command { get; set; }
        public SelectList Products;
        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;
        private readonly IProductApplication _productApplication;

        public EditModel(IColleagueDiscountApplication colleagueDiscountApplication, IProductApplication productApplication)
        {
            _colleagueDiscountApplication = colleagueDiscountApplication;
            _productApplication = productApplication;
        }

        public void OnGet(long id)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            command = _colleagueDiscountApplication.GetDetails(id);
        }
        public IActionResult OnPost() 
        {
            if (command != null)
            {
                _colleagueDiscountApplication.Edit(command);
                return RedirectToPage("./Index");
            }
            return Page();

        }
    }
}
