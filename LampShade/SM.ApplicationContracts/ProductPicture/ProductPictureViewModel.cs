namespace SM.ApplicationContracts.ProductPicture
{
    public class ProductPictureViewModel
    {
        public long Id { get; set; }
        public string Products { get; set; }
        public long ProductId {  get; set; }
        public string Picture { get; set; }
        public bool IsDeleted {  get; set; }
        public string CreationDate { get; set; }
    }
}
