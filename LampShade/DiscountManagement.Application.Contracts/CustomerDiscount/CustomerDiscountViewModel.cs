namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public long ProductId { get; set; }
        public int DiscountRate { get; set; }
        public string StartDay { get; set; }
        public DateTime StartDayGr { get; set; }
        public string EndDate { get; set; }
        public DateTime EndDateGr { get; set; }
        public string Reason { get; set; }
        public string CreationDate {  get; set; }
    }
}
