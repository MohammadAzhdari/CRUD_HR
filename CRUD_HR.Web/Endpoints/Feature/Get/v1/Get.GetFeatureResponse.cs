namespace CRUD_HR.Web.Endpoints.Feature.Get.v1
{
    public class GetFeatureResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
    }
}
