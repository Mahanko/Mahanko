using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Domain.Inventory
{
    public class InventoryAgg : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOpration> Oprations { get; private set; }
        protected InventoryAgg() { }

        public InventoryAgg(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }
        /// <summary>
        /// در حال حاضر چه تعدادی در انبار وجود دارد
        /// </summary>
        /// <returns></returns>
        private long CalculateCurrentCount()
        {
            var plus = Oprations.Where(x => x.Operation).Sum(x => x.Count);
            var Minus = Oprations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - Minus;
        }
        /// <summary>
        /// افزایش موجودی
        /// </summary>
        /// <param name="count">تعداد افزایش</param>
        /// <param name="OperatorId">چه کسی این کار را انجام میدهد </param>
        /// <param name="description">توضیحات</param>
        public void Increase(long count,long OperatorId,string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            var opration = new InventoryOpration(true,count, OperatorId, currentCount,description,0,Id);
            Oprations.Add(opration);
            InStock=currentCount > 0;
        }
        /// <summary>
        /// کاهش موجودی
        /// </summary>
        /// <param name="count">تعداد کاهش</param>
        /// <param name="OperatorId">چه کسی این کار را انجام میدهد</param>
        /// <param name="description">توضیحات</param>
        /// <param name="orderId">شماره سفارش مشتری</param>
        public void Reduce(long count, long OperatorId, string description, long orderId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var opration = new InventoryOpration(false, count, OperatorId, currentCount, description, orderId, Id);
            Oprations.Add(opration);
            InStock = currentCount > 0;


        }
    }
    public class InventoryOpration
    {
        public long Id { get; private set; }
        /// <summary>
        /// به انبار وارد شده یا خارج شده
        /// </summary>
        public bool Operation { get; private set; }
        /// <summary>
        /// چه تعداد وارد و خارج شده
        /// </summary>
        public long Count { get; private set; }
        /// <summary>
        /// چه شخصی اینکارو کرده
        /// </summary>
        public long OperatorId { get; private set; }
        /// <summary>
        /// تاریخ ورود و خروج
        /// </summary>
        public DateTime OprationDate { get; private set; }
        /// <summary>
        /// در تاریخی که این عملیات انجام شده موجودی انبار چقدر بوده است
        /// </summary>
        public long CurrentCount { get; private set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// اگر بر اساس سفارش مشتری بوده است شماره سفارش رو بزند
        /// </summary>
        public long OrderID { get; private set; }
        /// <summary>
        /// این عملیات مربوط به کدام انبار بوده
        /// </summary>
        public long InventoryId { get; set; }
        public InventoryAgg Inventory { get; set; }

        public InventoryOpration(bool operation, long count, long operatorId, long currentCount,
            string description, long orderID, long inventoryId)
        {
            Operation = operation;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            Description = description;
            OrderID = orderID;
            InventoryId = inventoryId;
        }
    }
}
