using CRUD_HR.Core.Entities;

namespace CRUD_HR.Web.Endpoints.Product.Update.v1
{
    public class UpdateProductRequest
    {
        public string Name { get; set; }
        public int CodeNumber { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}
