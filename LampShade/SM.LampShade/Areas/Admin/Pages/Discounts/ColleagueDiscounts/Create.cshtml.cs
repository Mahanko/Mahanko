using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SM.Application;
using SM.ApplicationContracts.Product;
using SM.ApplicationContracts.ProductCategory;

namespace SM.LampShade.Areas.Admin.Pages.Discount.ColleagueDiscounts
{
    public class CreateModel : PageModel
    {
        public DefineColleagueDiscount command { get; set; }
        public SelectList Products;
        private readonly IColleagueDiscountApplication _ColleagueDiscountApplication;
        private readonly IProductApplication _productApplication;

        public CreateModel(IColleagueDiscountApplication colleagueDiscountApplication, IProductApplication productApplication)
        {
            _ColleagueDiscountApplication = colleagueDiscountApplication;
            _productApplication = productApplication;
        }

        public void OnGet()
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        }

        public IActionResult OnPost(DefineColleagueDiscount command)
        {
            if (ModelState.IsValid)
            {
                _ColleagueDiscountApplication.Define(command);
                return RedirectToPage("./Index");
            }
            return Page();

        }
    }
}
