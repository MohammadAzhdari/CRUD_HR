namespace CRUD_HR.Web.Endpoints.Product.Get.v1
{
    public class GetProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CodeNumber { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public List<ProductImage> Images { get; set; }
    }

    public class ProductImage
    {
        private string _ImagePath { get; set; }
        public string ImagePath
        {
            set => _ImagePath = value;
            get => "file:///C:/Users/Mohammad/source/repos/CRUD_HR/CRUD_HR.Web/wwwroot/Images/" + _ImagePath;
        }
        public bool IsBanner { get; set; }
    }
}
