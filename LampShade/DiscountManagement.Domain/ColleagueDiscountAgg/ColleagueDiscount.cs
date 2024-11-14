using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public class ColleagueDiscount : EntityBase
    {
        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }
        public bool IsDeleted { get; private set; }
        protected ColleagueDiscount() { }
        public ColleagueDiscount(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
        }
        public void Edit(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            IsDeleted = false;
        }
        public void Remove()
        {
            IsDeleted = true;
        }
        public void Restore()
        {
            IsDeleted=false;
        }
    }
}
