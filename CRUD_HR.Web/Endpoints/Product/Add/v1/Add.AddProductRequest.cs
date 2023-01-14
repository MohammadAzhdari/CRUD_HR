namespace CRUD_HR.Web.Endpoints.Product.Add.v1
{
    public class AddProductRequest
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int CodeNumber { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
