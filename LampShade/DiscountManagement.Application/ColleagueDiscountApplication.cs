using _0_Framework.Application;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }
        /// <summary>
        /// تعریف یک تخفیف همکار
        /// </summary>
        /// <param name="command">DefineColleagueDiscount</param>
        /// <returns></returns>
        public OperationResult Define(DefineColleagueDiscount command)
        {
           var opration = new OperationResult();
            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);
            var colleaugeDiscount = new ColleagueDiscount(command.ProductId,command.DiscountRate);
            _colleagueDiscountRepository.Create(colleaugeDiscount);
            _colleagueDiscountRepository.SaveChanges();
            return opration.Successful();
            
        }
        /// <summary>
        /// ادیت کردن تخفیف همکار
        /// </summary>
        /// <param name="command">EditColleagueDiscount</param>
        public OperationResult Edit(EditColleagueDiscount command)
        {
            var ColleagueDiscount = _colleagueDiscountRepository.Get(command.Id);
            var opration = new OperationResult();
            if (ColleagueDiscount == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);
            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate ==
            command.DiscountRate && x.Id==command.Id))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);
            ColleagueDiscount.Edit(command.ProductId,command.DiscountRate);
            _colleagueDiscountRepository.SaveChanges();
            return opration.Successful();
        }
        /// <summary>
        /// مشخصات رو بر اساس ایدی نشان میدهد
        /// </summary>
        /// <param name="id">long میگیرد</param>
        /// <returns></returns>
        public EditColleagueDiscount GetDetails(long id)
        {
           return _colleagueDiscountRepository.GetDetails(id);
        }
        /// <summary>
        /// حذف میکند
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OperationResult Remove(long id)
        {
            var ColleagueDiscount = _colleagueDiscountRepository.Get(id);
            var opration = new OperationResult();
            if (ColleagueDiscount == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);
           
            ColleagueDiscount.Remove();
            _colleagueDiscountRepository.SaveChanges();
            return opration.Successful();
        }
        /// <summary>
        /// شی حذف شده را برمیگرداند
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OperationResult Restore(long id)
        {
            var ColleagueDiscount = _colleagueDiscountRepository.Get(id);
            var opration = new OperationResult();
            if (ColleagueDiscount == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            ColleagueDiscount.Restore();
            _colleagueDiscountRepository.SaveChanges();
            return opration.Successful();
        }
        /// <summary>
        /// بر اساسی سرچ میکند
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public List<ColleagueDiscountViewModel> Search(ColleagueSearchModel searchModel)
        {
           return _colleagueDiscountRepository.Search(searchModel);
        }
    }
}
