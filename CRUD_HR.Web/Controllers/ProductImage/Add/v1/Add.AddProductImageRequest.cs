namespace CRUD_HR.Web.Controllers.ProductImage.Add.v1
{
    public class AddProductImageRequest
    {
        public int ProductId { get; set; }
        public bool IsBanner { get; set; }
        public IFormFile File { get; set; }
    }
}
