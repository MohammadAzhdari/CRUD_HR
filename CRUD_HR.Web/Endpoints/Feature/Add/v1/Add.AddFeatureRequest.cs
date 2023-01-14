namespace CRUD_HR.Web.Endpoints.Feature.Add.v1
{
    public class AddFeatureRequest
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
    }
}
