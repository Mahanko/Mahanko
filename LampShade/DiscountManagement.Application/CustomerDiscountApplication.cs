using _0_Framework.Application;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        public readonly ICustomerDiscountReposiroty _customerDiscountReposiroty;

        public CustomerDiscountApplication(ICustomerDiscountReposiroty customerDiscountReposiroty)
        {
            _customerDiscountReposiroty = customerDiscountReposiroty;
        }

        public global::_0_Framework.Application.OperationResult Define(DefineCustomerDiscount command)
        {
            var opration = new OperationResult();
            if (_customerDiscountReposiroty.Exists(x => x.ProductId == command.ProductId && x.DiscountRate
            == command.DiscountRate))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);
            var stardate = command.StartDay.ToGeorgianDateTime();
            var enddate = command.EndDate.ToGeorgianDateTime();
            var customerDiscount = new CustomerDiscount(command.ProductId, command.DiscountRate,
                stardate, enddate, command.Reason);

            _customerDiscountReposiroty.Create(customerDiscount);
            _customerDiscountReposiroty.SaveChanges();
            return opration.Successful();


        }

        public global::_0_Framework.Application.OperationResult Edit(EditCustomerDiscount command)
        {
            var opration = new OperationResult();
            var customerDiscount = _customerDiscountReposiroty.Get(command.Id);
            if (customerDiscount == null)
                opration.Failed(ApplicationMessages.RecordNotFound);

            if (_customerDiscountReposiroty.Exists(x => x.ProductId == command.ProductId && x.DiscountRate
              == command.DiscountRate && x.Id != command.Id))
                opration.Failed(ApplicationMessages.DuplicatedRecord);

            var stardate = command.StartDay.ToGeorgianDateTime();
            var enddate = command.EndDate.ToGeorgianDateTime();
            customerDiscount.Edit(command.ProductId, command.DiscountRate, stardate, enddate, command.Reason);
            _customerDiscountReposiroty.SaveChanges();
            return opration.Successful();

        }

        public EditCustomerDiscount GetDetails(long id)
        {
          return _customerDiscountReposiroty.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _customerDiscountReposiroty.Search(searchModel);
        }
    }
}
